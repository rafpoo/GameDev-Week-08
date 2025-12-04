using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 3f;

    public Transform cameraTransform;

    float cameraPitch = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate hero left-right
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera up-down
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -40f, 60f);

        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
    }

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = (transform.forward * v) + (transform.right * h);

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
