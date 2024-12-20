using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuPause : MonoBehaviour
{
    public GameObject wristUI;
    public string mainVrSceneName = "MainVrScene";

    public bool activeWristUI = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButtonPressed(InputAction.CallbackContext context){
        if(context.performed){
            DisplayWristUI();
        }
    }

    public void DisplayWristUI()
    {
        if(activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
        }
        else if (!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
        }
    }

    public void ContinueGame(){
        wristUI.SetActive(false);
        activeWristUI = false;
    }

    public void GoToMainVrScene(){
        Debug.Log("гл меню");
        SceneManager.LoadScene(this.mainVrSceneName);
    }
}
