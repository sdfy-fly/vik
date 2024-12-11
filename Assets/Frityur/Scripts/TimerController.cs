using UnityEngine;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Ссылка на TextMeshPro для отображения таймера
    public float timerDuration = 10f; // Продолжительность таймера (в секундах)
    public float finishTimeDuration = 5f;
    private float timeRemaining;
    private float finishTimeRemaining = 5f;
    private bool isTimerRunning = false;
    private bool isFinishTimerRuning = false;

    public GameObject oilRiseObject; // Ссылка на объект, содержащий скрипт OilRiseController
    private OilRiseController oilRiseController; // Ссылка на сам скрипт

    private float defaultFontSize = 0.05f; // Стандартный размер шрифта
    private float shakeFontSize = 0.025f;   // Размер шрифта для текста "Встряхните"

    public GameObject triggerZoneBasket; // Ссылка на объект корзины с картошкой фри
    public GameObject activeChildObjectRaw; // Ссылка на дочерний объект, который должен быть активен
    public GameObject activeChildObjectCoocked;
    private bool isBasketInZone = false; // Флаг, находится ли корзина в триггер-зоне
    public AudioSource audioSource;
    public AudioClip soundTick;
    public AudioClip soundRing;

    public void StartTimer()
    {
        finishTimeDuration = 5f;
        finishTimeRemaining = 5f;
        if (oilRiseObject.GetComponent<OilRiseController>() != null 
            && oilRiseObject.GetComponent<OilRiseController>().isActive 
            && !isTimerRunning 
            && isBasketInZone // Корзина в триггер-зоне
            && activeChildObjectRaw.activeSelf // Дочерний объект активен
            && timerText.text == "Встряхнитe") 
        {
            Debug.Log("дожарка");
            finish();
        }
        // Проверяем все условия
        if (oilRiseObject.GetComponent<OilRiseController>() != null 
            && oilRiseObject.GetComponent<OilRiseController>().isActive 
            && !isTimerRunning 
            && isBasketInZone // Корзина в триггер-зоне
            && activeChildObjectRaw.activeSelf // Дочерний объект активен
            && timerText.text != "Встряхните") 
        {
            Debug.Log("первоначальная");
            TimerOperation();
        }
        // Проверяем все условия
        if (oilRiseObject.GetComponent<OilRiseController>() != null 
            && oilRiseObject.GetComponent<OilRiseController>().isActive 
            && !isTimerRunning 
            && !isBasketInZone // Корзина в триггер-зоне
            && activeChildObjectRaw.activeSelf // Дочерний объект активен
            && timerText.text == "Встряхните") 
        {
            Debug.Log("вторая");
            timerText.text = "Встряхнитe";
        }
    }

    private void finish(){
        activeChildObjectRaw.SetActive(false);
        activeChildObjectCoocked.SetActive(true);
        isFinishTimerRuning = true;
    }

    private void Update()
    {
        if(timerText.text == "Встряхните")
        {
            StartTimer();
        }

        isBasketInZone = triggerZoneBasket.GetComponent<AttachBasketToStove>().getIsBasketAttached();
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(); // Обновляем отображение каждую секунду
            }
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                UpdateTimerDisplay();
                timerText.color = Color.red; // Меняем цвет текста на красный
            }
        }

        if (isFinishTimerRuning)
        {
            if(finishTimeRemaining > 0)
            {
                finishTimeRemaining -= Time.deltaTime;
                UpdateFinishTimerDisplay();
            }
            else
            {
                finishTimeRemaining = 0;
                isFinishTimerRuning = false;
                UpdateFinishTimerDisplay();
                timerText.color = Color.green;
            }
        }
    }

    // Метод для начала таймера
    private void TimerOperation()
    {
        timeRemaining = timerDuration;
        isTimerRunning = true;
        timerText.color = Color.white; // Сброс цвета текста на белый при запуске таймера
        timerText.fontSize = defaultFontSize; // Сбрасываем размер шрифта на стандартный
        UpdateTimerDisplay(); // Обновляем отображение в начале
    }

    // Метод для обновления отображения таймера в формате "MM:SS"
    private void UpdateTimerDisplay()
    {
        if (timeRemaining <= 0)
        {
            timerText.text = "Встряхните"; // Устанавливаем текст при окончании таймера
            timerText.fontSize = shakeFontSize; // Меняем размер шрифта на меньший
            audioSource.loop = false; // Отключаем повторение звука Tick
            audioSource.Stop(); // Останавливаем текущий звук
            PlaySoundRing(); // Играем звук "Ring"
        }
        else
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeRemaining);
            timerText.text = timeSpan.ToString("mm\\:ss"); // Формат минуты:секунды
            timerText.fontSize = defaultFontSize; // Устанавливаем стандартный размер шрифта
            PlaySoundTick(); // Включаем звук "Tick" с повторением
        }
    }

    private void UpdateFinishTimerDisplay()
    {
        if (finishTimeRemaining <= 0)
        {
            timerText.text = "Готово"; // Устанавливаем текст при завершении
            timerText.fontSize = shakeFontSize;
            audioSource.loop = false; // Отключаем повторение звука Tick
            audioSource.Stop(); // Останавливаем текущий звук
            PlaySoundRing(); // Играем звук "Ring"
        }
        else
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(finishTimeRemaining);
            timerText.text = timeSpan.ToString("mm\\:ss");
            timerText.fontSize = defaultFontSize;
            PlaySoundTick(); // Включаем звук "Tick" с повторением
        }
    }



    private void PlaySoundRing()
    {
        if (audioSource != null && soundRing != null)
        {
            audioSource.loop = false; // Выключаем повторение
            audioSource.clip = soundRing; // Назначаем звук
            audioSource.Play(); // Запускаем воспроизведение
        }
        else
        {
            Debug.LogWarning("AudioSource или AudioClip для Ring не назначены.");
        }
    }

    private void PlaySoundTick()
    {
        if (audioSource != null && soundTick != null)
        {
            audioSource.clip = soundTick; // Назначаем звук
            audioSource.loop = true; // Включаем повторение
            if (!audioSource.isPlaying) // Если звук не играет, запускаем
            {
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("AudioSource или AudioClip для Tick не назначены.");
        }
    }

}
