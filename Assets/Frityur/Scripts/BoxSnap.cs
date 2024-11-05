using UnityEngine;

public class BoxSnap : MonoBehaviour
{
    public Transform snapPoint; // Точка привязки

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoxFree") || other.gameObject.CompareTag("BoxDer")) // Проверяем, что это коробка
        {
            // Примагничиваем коробку к snapPoint и устанавливаем поворот на (-90, 0, 90)
            other.transform.position = snapPoint.position;
            other.transform.rotation = Quaternion.Euler(-90, 0, 90);

            // Устанавливаем флаг "canBeOpened" в true
            Box box = other.GetComponent<Box>();
            if (box != null)
            {
                box.canBeOpened = true;

                // Проверяем, была ли коробка уже открыта
                if (!box.hasOpened)
                {
                    box.OpenDoors(); // Вызываем метод OpenDoors() только один раз
                    box.hasOpened = true; // Устанавливаем флаг, что коробка уже открыта
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BoxFree") || other.gameObject.CompareTag("BoxDer")) // Проверяем, что это коробка
        {
            // Устанавливаем флаг "canBeOpened" в false
            Box box = other.GetComponent<Box>();
            if (box != null)
            {
                box.canBeOpened = false;
            }
        }
    }
}
