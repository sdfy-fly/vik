using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public string fruitureSceneName = "SampleScene";
    public string drinksSceneName = "Drinks";
    public string buildingSceneName = "Sborka";


    public void GoToFruitureScene()
    {
        SceneManager.LoadScene(this.fruitureSceneName);
    }

    public void GoToDrinksScene()
    {
        SceneManager.LoadScene(this.drinksSceneName);
    }

    public void GoToBuildingScene()
    {
        SceneManager.LoadScene(this.buildingSceneName);
    }
}
