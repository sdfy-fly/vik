using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public string fruitureSceneName = "SampleScene";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToFruitureScene()
    {
        SceneManager.LoadScene(this.fruitureSceneName);
    }

}
