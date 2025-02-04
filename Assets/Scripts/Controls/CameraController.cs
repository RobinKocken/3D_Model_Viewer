using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Input input;

    [SerializeField] private Transform target;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float mouseMoveMultiplier;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float mouseSensMultiplier;

    [Header("Zoom")]
    [SerializeField] private float zoomDistance;
    [SerializeField] private float zoomAmount;

    private Vector2 cameraRotation;
    private Vector3 targetOffset;


    private bool canMove;
    private bool canRotate;

    private Vector2 mouseMove;
    private Vector2 mouseZoom;

    private Vector3 TargetPos
    {
        get
        {
            return target.position + targetOffset;
        }
    }

    private void Start()
    {
        input = new Input();
        input.ModelView.Enable();

        InitializeInput();
    }

    private void Update()
    {
        UpdateInput();
        Camera();
    }

    private void InitializeInput()
    {
        input.ModelView.Pan.performed += (InputAction.CallbackContext context) => canMove = true;
        input.ModelView.Rotate.performed += (InputAction.CallbackContext context) => canRotate = true;

        input.ModelView.Pan.canceled += (InputAction.CallbackContext context) => canMove = false;
        input.ModelView.Rotate.canceled += (InputAction.CallbackContext context) => canRotate = false;
    }

    private void UpdateInput()
    {
        mouseMove = input.ModelView.MousePos.ReadValue<Vector2>();
        mouseZoom = input.ModelView.Zoom.ReadValue<Vector2>();
    }

    private void Camera()
    {
        if(target == null) return;

        zoomDistance += Mathf.Clamp(mouseZoom.y, -zoomAmount, zoomAmount);
        cameraRotation += new Vector2(-mouseMove.y, mouseMove.x) * mouseSensMultiplier * Convert.ToInt32(canRotate);

        targetOffset += (-mouseMove.x * transform.right + -mouseMove.y * transform.up) * mouseMoveMultiplier * Convert.ToInt32(canMove);

        transform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
        transform.position = TargetPos + transform.forward * zoomDistance;

        //transform.rotation = Quaternion.Slerp(transform.rotation, newTargetRot, rotationSpeed * Time.deltaTime);
        //transform.position = Vector3.Slerp(transform.position, newTargetPos, moveSpeed * Time.deltaTime);
    }
}
