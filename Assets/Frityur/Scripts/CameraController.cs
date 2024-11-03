using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public float upDownRange = 60f;

    private float rotationX = 0f;

    private void Start()
    {
        // Скрываем курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Скрыть курсор
    }

    private void Update()
    {
        // Ввод мыши для поворота камеры
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -upDownRange, upDownRange);
        
        transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y + mouseX, 0);

        // Перемещение камеры
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // A/D
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // W/S

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement = transform.TransformDirection(movement);
        transform.position += movement;
    }
}
