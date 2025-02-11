using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Transform target;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float mouseMoveMultiplier;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float mouseSensMultiplier;
    [SerializeField] private float maxRot;

    [Header("Zoom")]
    [SerializeField] private float zoomDistance;
    [SerializeField] private float zoomAmount;
    [SerializeField] private Vector2 maxZoom;

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
            if(target == null)
            {
                return Vector3.zero + targetOffset;
            }
            else
            {
                return target.position + targetOffset;
            }
        }
    }

    private void Start()
    {
        ModelManager.Instance.OnModelSpawned += SetModel;

        GameManager.Instance.Input.ModelView.Pan.performed += (InputAction.CallbackContext context) => canMove = true;
        GameManager.Instance.Input.ModelView.Rotate.performed += (InputAction.CallbackContext context) => canRotate = true;

        GameManager.Instance.Input.ModelView.Pan.canceled += (InputAction.CallbackContext context) => canMove = false;
        GameManager.Instance.Input.ModelView.Rotate.canceled += (InputAction.CallbackContext context) => canRotate = false;
    }

    private void Update()
    {
        UpdateInput();
        Camera();
    }

    private void OnDestroy()
    {
        ModelManager.Instance.OnModelSpawned -= SetModel;

        GameManager.Instance.Input.ModelView.Pan.performed -= (InputAction.CallbackContext context) => canMove = true;
        GameManager.Instance.Input.ModelView.Rotate.performed -= (InputAction.CallbackContext context) => canRotate = true;

        GameManager.Instance.Input.ModelView.Pan.canceled -= (InputAction.CallbackContext context) => canMove = false;
        GameManager.Instance.Input.ModelView.Rotate.canceled -= (InputAction.CallbackContext context) => canRotate = false;
    }

    private void UpdateInput()
    {
        mouseMove = GameManager.Instance.Input.ModelView.MousePos.ReadValue<Vector2>();
        mouseZoom = GameManager.Instance.Input.ModelView.Zoom.ReadValue<Vector2>();
    }

    private void Camera()
    {
        zoomDistance -= Mathf.Clamp(mouseZoom.y, -zoomAmount, zoomAmount);
        zoomDistance = Mathf.Clamp(zoomDistance, maxZoom.x, maxZoom.y);

        cameraRotation += new Vector2(-mouseMove.y, mouseMove.x) * mouseSensMultiplier * Convert.ToInt32(canRotate);
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -maxRot, maxRot);

        targetOffset += (-mouseMove.x * transform.right + -mouseMove.y * transform.up) * mouseMoveMultiplier * Convert.ToInt32(canMove);

        transform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y + 180, 0);
        transform.position = TargetPos + transform.forward * -zoomDistance;
    }

    public void ResetOffset()
    {
        targetOffset = Vector3.zero;
    }

    public void SetModel(ModelData modelData, GameObject model)
    {
        target = model.transform;
        ResetOffset();
    }
}
