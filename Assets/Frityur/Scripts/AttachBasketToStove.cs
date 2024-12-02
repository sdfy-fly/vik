using UnityEngine;

public class AttachBasketToStove : MonoBehaviour
{
    // Точка привязки на плите
    public Transform snapPoint;

    // Желаемый поворот корзины при привязке
    public Quaternion desiredRotation;

    // Ссылка на объект корзины, которую нужно привязать
    public GameObject targetBasket;

    // Флаг для отслеживания, привязана ли корзина
    private bool isBasketAttached = false;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что объект совпадает с заданной корзиной
        if (other.gameObject == targetBasket && !isBasketAttached)
        {
            // Привязываем корзину к точке привязки
            other.transform.position = snapPoint.position;
            other.transform.rotation = desiredRotation;

            isBasketAttached = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Сбрасываем привязку, если корзина покидает триггер
        if (other.gameObject == targetBasket && isBasketAttached)
        {
            isBasketAttached = false;
        }
    }

    public bool getIsBasketAttached() {
        return isBasketAttached;
    }
}
