using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineInputAxisController _cinemachineInputAxisController;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _cinemachineInputAxisController = GetComponent<CinemachineInputAxisController>();

        _cinemachineInputAxisController.enabled = false;
    }

    private void Start()
    {
        InputManager.Instance.OnLeftMouseClicked += EnableCameraMovement;
        InputManager.Instance.OnLeftMouseReleased += DisableCameraMovement;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnLeftMouseClicked -= EnableCameraMovement;
        InputManager.Instance.OnLeftMouseReleased -= DisableCameraMovement;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void DisableCameraMovement() => _cinemachineInputAxisController.enabled = false;

    private void EnableCameraMovement() => _cinemachineInputAxisController.enabled = true;
}
