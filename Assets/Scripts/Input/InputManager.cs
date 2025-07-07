using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action OnLeftMouseClicked;
    public event Action OnLeftMouseReleased;

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
        _cameraInputAction.MouseInteractions.PrimaryClick.performed += FirePrimaryClickEvent;
        _cameraInputAction.MouseInteractions.PrimaryClick.canceled += CancelPrimaryClickEvent;
    }

    private void OnDestroy()
    {
        _cameraInputAction.MouseInteractions.PrimaryClick.performed -= FirePrimaryClickEvent;
        _cameraInputAction.MouseInteractions.PrimaryClick.canceled -= CancelPrimaryClickEvent;
        _cameraInputAction.Disable();
    }

    // Signal Methods------------------------------------------------------------------------------

    private void FirePrimaryClickEvent(UnityEngine.InputSystem.InputAction.CallbackContext context) => OnLeftMouseClicked?.Invoke();

    private void CancelPrimaryClickEvent(UnityEngine.InputSystem.InputAction.CallbackContext context) => OnLeftMouseReleased?.Invoke();
}
