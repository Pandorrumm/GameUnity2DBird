using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	//Для PLAY

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //можно в LoadScene("имя сцены")
    }
     public void ExitGame()
    {
        Debug.Log("EXIT!");
        Application.Quit();
    }
}
