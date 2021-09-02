using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookControl : MonoBehaviour
{
    // How fast the mouse will rotate the camera
    [SerializeField]
    private float mouseSensitivity = 10.0f;

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

        cameraTransform.localEulerAngles = new Vector3(rotation, 0.0f, 0.0f);
    }
}
