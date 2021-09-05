using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookControl : MonoBehaviour
{
    // How fast the mouse will rotate the camera
    [SerializeField]
    private float mouseSensitivity = 10.0f;

    [SerializeField]
    private float gamepadSpeed = 10.0f;

    [SerializeField]
    private Transform cameraTransform;

    private float rotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Controls horizontal look rotation
    public void LookHorizontal(float mouseX)
    {
        transform.Rotate((Vector3.up * mouseX) * mouseSensitivity * Time.deltaTime);
    }

    // Controls vertical look rotation
    public void LookVertical(float mouseY)
    {
        rotation -= mouseY * mouseSensitivity * Time.deltaTime;
        rotation = Mathf.Clamp(rotation, -80.0f, 80.0f);

        cameraTransform.localEulerAngles = Vector3.right * rotation;
    }

    // Controls horizontal look rotation on gamepad
    public void GamepadLookHorizontal(float gamepadX)
    {
        transform.Rotate((Vector3.up * gamepadX) * gamepadSpeed * Time.deltaTime);
    }

    // Controls vertical look rotation on gamepad
    public void GamepadLookVertical(float gamepadY)
    {
        rotation -= gamepadY * gamepadSpeed * Time.deltaTime;
        rotation = Mathf.Clamp(rotation, -80.0f, 80.0f);

        cameraTransform.localEulerAngles = Vector3.right * rotation;
    }
}
