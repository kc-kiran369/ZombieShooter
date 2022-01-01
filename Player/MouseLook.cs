using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform PlayerBody;
    public static float MouseSensitivity = 70f;
    [SerializeField] byte maxLookAngleInY = 50;         //fifty by default
    float xRotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (GameState.currentGameState == GameState.CurrentGameState.Playing)
        {
            ProcessMouseLook();
        }
    }

    private void ProcessMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngleInY, maxLookAngleInY);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
