using UnityEngine;

public class BoxSnap : MonoBehaviour
{
    public Transform snapPoint; // Точка привязки

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box")) // Проверяем, что это коробка
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            
            // Примагничиваем коробку к snapPoint и устанавливаем поворот на (0, 0, 90)
            other.transform.position = snapPoint.position;
            other.transform.rotation = Quaternion.Euler(-90, 0, 90);

            // Устанавливаем флаг "canBeOpened" в true
            Box box = other.GetComponent<Box>();
            if (box != null)
            {
                box.canBeOpened = true;
            }
        }
    }
}
