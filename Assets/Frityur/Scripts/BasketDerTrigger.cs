using UnityEngine;
using System.Collections;

public class BasketDerTrigger : MonoBehaviour
{
    public Transform snapPoint; // snapPoint для корзины
    public Vector3 additionalRotation; // Дополнительный угол для корзины
    public GameObject potato; // Картошка в корзине
    public GameObject potatoPrefab; // Префаб картошки для полёта
    public Transform spawnPoint; // Точка начала полёта картошки
    public Transform targetPoint; // Точка, куда картошка будет лететь (например, корзина)
    public AudioSource audioSource;
    public AudioClip fallPotatoes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BasketDer")) // Проверяем тег корзины
        {
            // Устанавливаем корзину на snapPoint
            other.transform.position = snapPoint.position;
            other.transform.rotation = snapPoint.rotation * Quaternion.Euler(additionalRotation);
            other.transform.parent = snapPoint;

            // Запускаем проверку с задержкой и анимацией полёта картошки
            StartCoroutine(CheckAndAnimatePotatoWithDelay(other.transform));
            Debug.Log("Корзина прикреплена к snapPoint!");
        }
    }

    private IEnumerator CheckAndAnimatePotatoWithDelay(Transform basket)
    {
        // Ждём 2 секунды
        yield return new WaitForSeconds(2f);

        // Проверяем, что корзина всё ещё находится на snapPoint
        if (basket.parent == snapPoint)
        {
            // Проверяем условие и активируем анимацию полёта картошки
            var bunker = GameObject.FindWithTag("BunkerDer").GetComponent<Bunker>();
            if (bunker != null && bunker.potatoCount >= 1 && !potato.activeSelf)
            {
                bunker.potatoCount -= 1;
                Debug.Log("Поток активации полёта картошки начат.");
                
                // Запускаем анимацию полёта картошки
                yield return StartCoroutine(SpawnAndAnimatePotato()); // Ждём завершения анимации
                
                // После завершения анимации активируем картошку в корзине
                potato.SetActive(true);
                Debug.Log("Картошка активирована и potatoCount уменьшен.");
            }
        }
        else
        {
            Debug.Log("Корзина перемещена из snapPoint до завершения ожидания.");
        }
    }

    private IEnumerator SpawnAndAnimatePotato()
    {
        Debug.Log("Запуск полёта картошки...");

        // Создаём временный объект картошки на стартовой позиции
        GameObject flyingPotato = Instantiate(potatoPrefab, spawnPoint.position, Quaternion.identity);

        float duration = 2f; // Время полёта картошки
        float elapsedTime = 0f;

        // Анимация полёта картошки от spawnPoint к targetPoint
        while (elapsedTime < duration)
        {
            flyingPotato.transform.position = Vector3.Lerp(spawnPoint.position, targetPoint.position, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            
            Debug.Log($"Процесс полёта: {elapsedTime}/{duration}");
            
            yield return null;
        }

        // Устанавливаем конечную позицию точно в targetPoint
        flyingPotato.transform.position = targetPoint.position;

        // Удаляем временный объект после полёта
        Destroy(flyingPotato);
        PlayFallSound();
        Debug.Log("Картошка достигла конечной точки и была удалена.");
    }

    private void PlayFallSound()
    {
        if (audioSource != null && fallPotatoes != null)
        {
            audioSource.clip = fallPotatoes; // Назначаем звук в AudioSource
            audioSource.Play();           // Запускаем воспроизведение
        }
        else
        {
            Debug.LogWarning("AudioSource или AudioClip не назначены.");
        }
    }
}
