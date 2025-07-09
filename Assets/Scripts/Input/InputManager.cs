using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action OnRightMouseClicked;
    public event Action OnRightMouseReleased;
    public event Action<Vector3> OnLeftMouseClicked;

    public static InputManager Instance { get; private set; }

    private CameraInputAction _cameraInputAction;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;

            _cameraInputAction = new CameraInputAction();

            // Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Start()
    {
        _cameraInputAction.Enable();

        _cameraInputAction.MouseInteractions.SecondaryClick.performed += FireSecondaryClickEvent;
        _cameraInputAction.MouseInteractions.SecondaryClick.canceled += CancelSecondaryClickEvent;

        _cameraInputAction.MouseInteractions.PrimaryClick.performed += FirePrimaryClickEvent;
    }

    private void OnDestroy()
    {
        _cameraInputAction.MouseInteractions.SecondaryClick.performed -= FireSecondaryClickEvent;
        _cameraInputAction.MouseInteractions.SecondaryClick.canceled -= CancelSecondaryClickEvent;

        _cameraInputAction.MouseInteractions.PrimaryClick.performed -= FirePrimaryClickEvent;
        _cameraInputAction.Disable();
    }

    // Signal Methods------------------------------------------------------------------------------

    private void FireSecondaryClickEvent(UnityEngine.InputSystem.InputAction.CallbackContext context) => OnRightMouseClicked?.Invoke();

    private void CancelSecondaryClickEvent(UnityEngine.InputSystem.InputAction.CallbackContext context) => OnRightMouseReleased?.Invoke();

    private void FirePrimaryClickEvent(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
        {
            if (hit.collider.TryGetComponent(out ITarget target))
            {
                OnLeftMouseClicked?.Invoke(target.MyPosition);
            }
        }
    }
}
