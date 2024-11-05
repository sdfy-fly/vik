using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Box : MonoBehaviour
{
    public bool canBeOpened = false;     // Флаг для открытия коробки.
    public Transform leftDoor;           // Ссылка на левую дверцу
    public Transform rightDoor;          // Ссылка на правую дверцу
    public float openAngle = 90f;        // Угол открытия дверей
    public float openSpeed = 2f;         // Скорость открытия

    private bool isOpening = false;      // Внутренний флаг для открытия дверей
    public bool hasOpened = false;       // Флаг, указывающий, была ли коробка открыта

    // Метод, который будет вызываться при взаимодействии
    public void OnSelectEntered()
    {
        if (canBeOpened && !isOpening && !hasOpened) // Проверяем флаг hasOpened
        {
            isOpening = true; // Начинаем процесс открытия
            OpenDoors();
            hasOpened = true; // Устанавливаем флаг, что коробка уже открыта
        }
    }

    public void OpenDoors()
    {
        StartCoroutine(OpenDoorCoroutine()); // Запускаем корутину открытия дверей
    }

    private System.Collections.IEnumerator OpenDoorCoroutine()
    {
        float elapsed = 0f;

        Quaternion leftStartRotation = leftDoor.localRotation;
        Quaternion leftEndRotation = leftStartRotation * Quaternion.Euler(-openAngle, 0, 0); // Левую дверцу открываем влево

        Quaternion rightStartRotation = rightDoor.localRotation;
        Quaternion rightEndRotation = rightStartRotation * Quaternion.Euler(openAngle, 0, 0); // Правую дверцу открываем вправо

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * openSpeed;

            leftDoor.localRotation = Quaternion.Slerp(leftStartRotation, leftEndRotation, elapsed);
            rightDoor.localRotation = Quaternion.Slerp(rightStartRotation, rightEndRotation, elapsed);

            yield return null;
        }
    }
}
