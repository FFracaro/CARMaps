using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class PinchZoomMap : MonoBehaviour
{
    [SerializeField]
    float MaxZoom = 0.55f;

    [SerializeField]
    float MinZoom = 0.2f;

    [SerializeField]
    float ZoomAmount = 0.3f;

    [SerializeField]
    float ZoomSpeed = 0.1f;

    [SerializeField]
    Camera PinCam;

    [SerializeField]
    CinemachineVirtualCamera VirtualCam;

    private TouchControls controls;
    private Coroutine ZoomCoroutine;

    private void Awake()
    {
        controls = new TouchControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Touch.SecondFingerContact.started += _ => ZoomStart();
        controls.Touch.SecondFingerContact.canceled += _ => ZoomEnd();
    }

    private void ZoomStart()
    {
        ZoomCoroutine = StartCoroutine(ZoomDetection());
    }

    private void ZoomEnd()
    {
        StopCoroutine(ZoomCoroutine);
    }

    IEnumerator ZoomDetection()
    {
        float previousFingersDistance = 0f;
        float distance = 0f;

        while(true)
        {
            distance = Vector2.Distance(controls.Touch.FirstFinger.ReadValue<Vector2>(), controls.Touch.SecondFinger.ReadValue<Vector2>());

            // Detecção
            if(distance < previousFingersDistance)
            {
                // zoom out
                if(VirtualCam.m_Lens.OrthographicSize + ZoomAmount <= MaxZoom)
                {
                    VirtualCam.m_Lens.OrthographicSize = Mathf.Lerp(VirtualCam.m_Lens.OrthographicSize, VirtualCam.m_Lens.OrthographicSize + ZoomAmount, Time.deltaTime * ZoomSpeed);
                    PinCam.orthographicSize = Mathf.Lerp(PinCam.orthographicSize, PinCam.orthographicSize + ZoomAmount, Time.deltaTime * ZoomSpeed);
                }
                else
                {
                    VirtualCam.m_Lens.OrthographicSize = Mathf.Lerp(VirtualCam.m_Lens.OrthographicSize, MaxZoom, Time.deltaTime * ZoomSpeed);
                    PinCam.orthographicSize = Mathf.Lerp(PinCam.orthographicSize, MaxZoom, Time.deltaTime * ZoomSpeed);
                }
            }
            else if(distance > previousFingersDistance)
            {
                // zoom in
                if(VirtualCam.m_Lens.OrthographicSize - ZoomAmount >= MinZoom)
                {
                    VirtualCam.m_Lens.OrthographicSize = Mathf.Lerp(VirtualCam.m_Lens.OrthographicSize, VirtualCam.m_Lens.OrthographicSize - ZoomAmount, Time.deltaTime * ZoomSpeed);
                    PinCam.orthographicSize = Mathf.Lerp(PinCam.orthographicSize, PinCam.orthographicSize - ZoomAmount, Time.deltaTime * ZoomSpeed);
                }
                else
                {
                    VirtualCam.m_Lens.OrthographicSize = Mathf.Lerp(VirtualCam.m_Lens.OrthographicSize, MinZoom, Time.deltaTime * ZoomSpeed);
                    PinCam.orthographicSize = Mathf.Lerp(PinCam.orthographicSize, MinZoom, Time.deltaTime * ZoomSpeed);
                }
            }

            // atualiza a distancia atual para o prox loop
            previousFingersDistance = distance;

            yield return null;
        }
    }
}
