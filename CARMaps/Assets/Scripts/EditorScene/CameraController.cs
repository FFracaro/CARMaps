using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    //Movement variables
    private const float InternalMoveTargetSpeed = 8;
    private const float InternalMoveSpeed = 4;
    private Vector3 _moveTarget;
    private Vector3 _moveDirection;

    /// <summary>
    /// Sets the direction of movement based on the input provided by the player
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        //Read the input value that is being sent by the Input System
        Vector2 value = context.ReadValue<Vector2>();
        //Store the value as a Vector3, making sure to move the Y input on the Z axis.
        _moveDirection = new Vector3(value.x, 0, value.y);
        //Increment the new move Target position of the camera
        _moveTarget += (transform.forward * _moveDirection.z + transform.right *
            _moveDirection.x) * Time.fixedDeltaTime * InternalMoveTargetSpeed;
    }
    private void LateUpdate()
    {
        //Lerp  the camera to a new move target position
        transform.position = Vector3.Lerp(transform.position, _moveTarget, Time.deltaTime * InternalMoveSpeed);
    }
}
