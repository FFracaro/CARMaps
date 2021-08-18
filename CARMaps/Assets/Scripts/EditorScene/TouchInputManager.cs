using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Cinemachine;

public class TouchInputManager : MonoBehaviour
{
    [SerializeField]
    GameObject Pin;

    [SerializeField]
    CinemachineVirtualCamera VirtualCam;

    [SerializeField]
    bool AddingNewPin = false;

    public float touchSpeed = 10f;

    private Vector3 _moveDirection;
    public float InternalMoveSpeed = 4;
    private float zAxis = 0;

    [SerializeField]
    PolygonCollider2D CameraBounds;

    private bool IsDragIconOn = false;

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        _moveDirection = transform.position;
        zAxis = transform.position.z;
    }

    private void Update()
    {
        if(AddingNewPin)
        {
            AddingNewPin = false;

            StartCoroutine(InstantiatePin());
        }
        else if(Touch.activeFingers.Count == 1)
        {
            if (!IsDragIconOn)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Touch.activeTouches[0].touchId))
                {
                    MoveCamera(Touch.activeTouches[0]);
                }
            }
        }
    }

    IEnumerator InstantiatePin()
    {
        yield return new WaitForSeconds(0.2f);

        while(true)
        {
            if (Touch.activeFingers.Count == 1)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Touch.activeTouches[0].touchId))
                {
                    //Instantiate Object
                    GameObject go = Instantiate(Pin, Camera.main.ScreenToWorldPoint(new Vector3 (Touch.activeTouches[0].screenPosition.x, Touch.activeTouches[0].screenPosition.y, 0.506f)), Quaternion.identity) as GameObject;
                    // Tranform as child

                    go.transform.SetParent(GameObject.Find("Pins").transform);

                    AddingNewPin = false;

                    yield break;
                }
            }

            yield return null;
        }       
    }

    private void MoveCamera(Touch touch)
    {
        //1
        if (touch.phase != TouchPhase.Moved)
        {
            return;
        }
        Debug.Log("Clicked.");
        Vector3 newPosition = new Vector3(-touch.delta.normalized.x, -touch.delta.normalized.y, 0) * Time.deltaTime * touchSpeed;
        Move(newPosition);
    }

    /// <summary>
    /// Sets the direction of movement based on the input provided by the player
    /// </summary>
    public void Move(Vector3 value)
    {
        _moveDirection = transform.position + value;
        _moveDirection.x = Mathf.Clamp(_moveDirection.x, CameraBounds.bounds.min.x, CameraBounds.bounds.max.x);
        _moveDirection.y = Mathf.Clamp(_moveDirection.y, CameraBounds.bounds.min.y, CameraBounds.bounds.max.y);
    }
    

    private void LateUpdate()
    {
        //Lerp  the camera to a new move target position
        transform.position = Vector3.Lerp(transform.position, _moveDirection, Time.deltaTime * InternalMoveSpeed);

        //transform.position = VirtualCam.State.FinalPosition;
    }

    public void IsPinBeingDragged(bool value)
    {
        this.IsDragIconOn = value;
    }

    public void AddNewPin(bool value)
    {
        this.AddingNewPin = value;
    }
}
