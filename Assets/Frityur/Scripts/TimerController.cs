using UnityEngine;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Ссылка на TextMeshPro для отображения таймера
    public float timerDuration = 10f; // Продолжительность таймера (в секундах)
    private float timeRemaining;
    private bool isTimerRunning = false;

    // Метод для начала таймера
    public void StartTimer()
    {
        timeRemaining = timerDuration;
        isTimerRunning = true;
        timerText.color = Color.white; // Сброс цвета текста на белый при запуске таймера
        UpdateTimerDisplay(); // Обновляем отображение в начале
    }

    // Метод, запускающийся при клике мышью на кнопку
    private void OnMouseDown()
    {
        StartTimer(); // Запуск таймера при клике
    }

    private void Update()
    {
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
    }

    // Метод для обновления отображения таймера в формате "MM:SS"
    private void UpdateTimerDisplay()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeRemaining);
        timerText.text = timeSpan.ToString("mm\\:ss"); // Формат минуты:секунды
    }
}
