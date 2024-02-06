using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadSceneAsync("IntroCutscene");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
