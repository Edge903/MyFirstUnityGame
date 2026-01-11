using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 1f;
    public Transform cameraPivot;

    float pitch, yaw;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pitch = 0f;
        yaw = transform.eulerAngles.y;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        
        transform.eulerAngles = new Vector3(0f, yaw, 0f);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
