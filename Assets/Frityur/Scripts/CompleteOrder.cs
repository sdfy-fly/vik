using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteOrder : MonoBehaviour
{
    [SerializeField] private GameObject finished; // Объект, содержащий SnapingFinished
    [SerializeField] private string name; // Имя для поиска объектов по тегу
    public AudioSource audioSource;
    public AudioClip soundComplete;

    public void Complete()
    {
        // Получаем список привязанных объектов
        List<GameObject> finishedOrder = finished.GetComponent<SnapingFinished>().snapPointOccupied;

        // Проходим по всему списку finishedOrder
        for (int i = 0; i < finishedOrder.Count; i++)
        {
            // Проверяем, если тег объекта совпадает с name
            if (finishedOrder[i] != null && finishedOrder[i].CompareTag(name))
            {
                PlaySoundComplete();
                // Удаляем объект из сцены
                Destroy(finishedOrder[i]);

                // Скрываем объект, на котором висит CompleteOrder
                StartCoroutine(HideObjectAfterDelay(1f));
                // Выходим из метода, так как нам нужно скрыть объект только один раз
                break;
            }
        }
    }

   private void PlaySoundComplete()
    {
        if (audioSource != null && soundComplete != null)
        {
            if (!audioSource.isActiveAndEnabled)
            {
                audioSource.enabled = true; // Включаем компонент, если он был выключен
            }

            audioSource.clip = soundComplete; // Назначаем звук
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource или AudioClip для Tick не назначены.");
        }
    }

    private IEnumerator HideObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Ожидаем заданное количество секунд
        gameObject.SetActive(false); // Скрываем объект
    }
}
