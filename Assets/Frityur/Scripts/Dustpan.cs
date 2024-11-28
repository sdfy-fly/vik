using UnityEngine;

public class Dustpan : MonoBehaviour
{
    [SerializeField] private string targetTag;  // Тег целевого объекта (пустая упаковка картошки фри)
    [SerializeField] private GameObject hiddenObject;  // Картошка фри в совке
    [SerializeField] private GameObject replacementObject;  // Новый объект, который заменит упаковку

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, имеет ли объект нужный тег (пустая упаковка картошки фри)
        if (other.CompareTag(targetTag))
        {
            // Скрываем картошку фри в совке
            if (hiddenObject != null)
            {
                hiddenObject.SetActive(false);
                Debug.Log($"{hiddenObject.name} скрыта в совке.");
            }
            else
            {
                Debug.LogWarning("Объект картошки фри не назначен!");
            }

            // Заменяем упаковку картошки фри на новый объект
            if (replacementObject != null)
            {
                // Сохраняем позицию и вращение упаковки
                Vector3 position = other.transform.position;
                Quaternion rotation = other.transform.rotation;

                // Подменяем объект на новый
                Instantiate(replacementObject, position, rotation);
                Debug.Log($"{other.name} заменён на {replacementObject.name}");

                // Удаляем старую упаковку картошки фри
                Destroy(other.gameObject);
            }
            else
            {
                Debug.LogWarning("Объект для подмены не назначен!");
            }
        }
    }
}
