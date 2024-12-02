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

    public void StartTimer()
    {
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
            Debug.Log("первоначальная хуйня");
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
            Debug.Log("вторая хуйня");
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
        }
        else
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeRemaining);
            timerText.text = timeSpan.ToString("mm\\:ss"); // Формат минуты:секунды
            timerText.fontSize = defaultFontSize; // Устанавливаем стандартный размер шрифта
        }
    }

    private void UpdateFinishTimerDisplay()
    {
        if(finishTimeRemaining <= 0)
        {
            timerText.text = "Готово";
            timerText.fontSize = shakeFontSize;
        }
        else
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(finishTimeRemaining);
            timerText.text = timeSpan.ToString("mm\\:ss");
            timerText.fontSize = defaultFontSize;
        }
    }
}
