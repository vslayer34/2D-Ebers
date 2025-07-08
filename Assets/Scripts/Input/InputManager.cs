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

        _cameraInputAction.MouseInteractions.SecondaryClick.performed += FireSecondaryClickEvent;
        _cameraInputAction.MouseInteractions.SecondaryClick.canceled += CancelSecondaryClickEvent;
    }

    private void OnDestroy()
    {
        _cameraInputAction.MouseInteractions.SecondaryClick.performed -= FireSecondaryClickEvent;
        _cameraInputAction.MouseInteractions.SecondaryClick.canceled -= CancelSecondaryClickEvent;
        _cameraInputAction.Disable();
    }

    // Signal Methods------------------------------------------------------------------------------

    private void FireSecondaryClickEvent(UnityEngine.InputSystem.InputAction.CallbackContext context) => OnLeftMouseClicked?.Invoke();

    private void CancelSecondaryClickEvent(UnityEngine.InputSystem.InputAction.CallbackContext context) => OnLeftMouseReleased?.Invoke();
}
