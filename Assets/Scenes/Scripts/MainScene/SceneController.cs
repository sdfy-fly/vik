using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public GameObject welcomeScene;
    public GameObject gameModeScene;
    public GameObject levelScene;

    // Start is called before the first frame update
    void Start()
    {
        this.welcomeScene.SetActive(true);
        this.gameModeScene.SetActive(false);
        this.levelScene.SetActive(false);
    }

    public void StartGame()
    {
        this.welcomeScene.SetActive(false);
        this.gameModeScene.SetActive(true);
        this.levelScene.SetActive(false);
    }

    public void ExitGame()
    {
        // Если игра запущена в редакторе Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Если игра запущена как отдельное приложение, завершить его
            Application.Quit();
        #endif
    }

    public void SetTrainGameMode()
    {
        this.welcomeScene.SetActive(false);
        this.gameModeScene.SetActive(false);
        this.levelScene.SetActive(true);
    }

    public void SetEducationGameMode()
    {
        this.welcomeScene.SetActive(false);
        this.gameModeScene.SetActive(false);
        this.levelScene.SetActive(true);
    }

}
