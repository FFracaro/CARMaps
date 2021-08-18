using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class TouchInputPinMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera mainCamera;

    float zAxis = 0;
    Vector3 clickOffset = Vector3.zero;

    [SerializeField]
    GameObject _pin;

    TouchInputManager TouchManager;

    // Use this for initialization
    void Start()
    {
        TouchManager = FindObjectOfType<TouchInputManager>();
        mainCamera = Camera.main;
        if (mainCamera.GetComponent<PhysicsRaycaster>() == null)
            mainCamera.gameObject.AddComponent<PhysicsRaycaster>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        zAxis = _pin.transform.position.z;
        clickOffset = _pin.transform.position - mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, zAxis)) + new Vector3(0, 0.001f, 0);
        _pin.transform.position = new Vector3(_pin.transform.position.x, _pin.transform.position.y, zAxis);

        TouchManager.IsPinBeingDragged(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Use Offset To Prevent Sprite from Jumping to where the finger is
        Vector3 tempVec = mainCamera.ScreenToWorldPoint(eventData.position) + clickOffset;
        tempVec.z = zAxis; //Make sure that the z zxis never change


        _pin.transform.position = tempVec;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponentInParent<PinInfo>().UpdatePinLocations(_pin.transform.localPosition, _pin.transform.position);
        zAxis = _pin.transform.position.z;
        _pin.transform.position = new Vector3(_pin.transform.position.x, _pin.transform.position.y, zAxis);

        TouchManager.IsPinBeingDragged(false);
    }

    //Add Event System to the Camera
    void addEventSystem()
    {
        GameObject eventSystem = new GameObject("EventSystem");
        eventSystem.AddComponent<EventSystem>();
        eventSystem.AddComponent<StandaloneInputModule>();
    }
}
