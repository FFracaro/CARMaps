using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class DragCameraMap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    CinemachineVirtualCamera VirtualCam;

    [SerializeField]
    Camera PinCam;

    Camera mainCamera;
    float zAxis = 0;
    Vector3 clickOffset = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera.GetComponent<PhysicsRaycaster>() == null)
            mainCamera.gameObject.AddComponent<PhysicsRaycaster>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        zAxis = VirtualCam.transform.position.z;       
        clickOffset = VirtualCam.transform.position - mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, zAxis)) + new Vector3(0, 20, 0);
        VirtualCam.transform.position = new Vector3(VirtualCam.transform.position.x, VirtualCam.transform.position.y, zAxis);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Use Offset To Prevent Sprite from Jumping to where the finger is
        Vector3 tempVec = mainCamera.ScreenToWorldPoint(eventData.position) + clickOffset;
        tempVec.z = zAxis; //Make sure that the z zxis never change
        VirtualCam.transform.position = tempVec;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        zAxis = VirtualCam.transform.position.z;
        VirtualCam.transform.position = new Vector3(VirtualCam.transform.position.x, VirtualCam.transform.position.y, zAxis);
    }

    //Add Event System to the Camera
    void addEventSystem()
    {
        GameObject eventSystem = new GameObject("EventSystem");
        eventSystem.AddComponent<EventSystem>();
        eventSystem.AddComponent<StandaloneInputModule>();
    }
}
