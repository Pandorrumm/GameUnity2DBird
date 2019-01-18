
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //можно в LoadScene("имя сцены")
    }
    public void ExitGame()
    {
         Application.Quit();
    }
}
