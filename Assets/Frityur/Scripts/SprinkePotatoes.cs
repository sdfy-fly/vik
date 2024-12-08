using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinkeFree : MonoBehaviour
{
    public GameObject basketFree;
    public GameObject basketDer;
    public GameObject potatoFree;
    public GameObject potatoDer;
    public GameObject potatoFreePacking;
    public GameObject potatoDerPacking;
    public AudioSource audioSource;
    public AudioClip fallPotatoes;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject == basketFree && potatoFree.activeSelf && !potatoFreePacking.activeSelf){
            potatoFreePacking.SetActive(true);
            potatoFree.SetActive(false);
            PlayFallSound();
        }
        if (other.gameObject == basketDer && potatoDer.activeSelf && !potatoDerPacking.activeSelf){
            potatoDerPacking.SetActive(true);
            potatoDer.SetActive(false);
            PlayFallSound();
        }
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
