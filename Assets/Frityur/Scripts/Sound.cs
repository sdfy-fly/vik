using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на AudioSource
    public AudioClip soundGrab;     // Переменная для хранения звука
    public AudioClip openFridge;
    public AudioClip openDoor;

    // Метод для воспроизведения звука
    public void PlaySoundGrab()
    {
        if (audioSource != null && soundGrab != null)
        {
            audioSource.clip = soundGrab; // Назначаем звук в AudioSource
            audioSource.Play();           // Запускаем воспроизведение
        }
        else
        {
            Debug.LogWarning("AudioSource или AudioClip не назначены.");
        }
    }

    public void PlaySoundOpenFridge()
    {
        if (audioSource != null && openFridge != null)
        {
            audioSource.clip = openFridge; // Назначаем звук в AudioSource
            audioSource.Play();           // Запускаем воспроизведение
        }
        else
        {
            Debug.LogWarning("AudioSource или AudioClip не назначены.");
        }
    }
    public void PlaySoundOpenDoor()
    {
        if (audioSource != null && openDoor != null)
        {
            audioSource.clip = openDoor; // Назначаем звук в AudioSource
            audioSource.Play();           // Запускаем воспроизведение
        }
        else
        {
            Debug.LogWarning("AudioSource или AudioClip не назначены.");
        }
    }
}
