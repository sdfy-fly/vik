using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorController : MonoBehaviour
{
    public Transform door; // Ссылка на объект двери
    public Transform handle; // Ссылка на ручку

    private bool isOpen = false; // Состояние двери

    private void Update()
    {
        // Проверка нажатия левой кнопки мыши
        // if (Input.GetMouseButtonDown(0)) // 0 - левая кнопка мыши
        // {
        //     OnHandleGrab();
        // }
    }

    // Метод, который будет вызываться, когда пользователь хватает ручку или нажимает кнопку мыши
    public void OnHandleGrab()
    {
        // Начать поворот двери
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // Поворот двери на 90 градусов (или нужный вам угол)
        door.localRotation = Quaternion.Euler(0, 0, -90);
        isOpen = true;
    }

    private void CloseDoor()
    {
        // Поворот двери обратно
        door.localRotation = Quaternion.Euler(0, 0, 0);
        isOpen = false;
    }
}
