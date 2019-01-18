using UnityEngine.SceneManagement;
using UnityEngine;

public class TrainingMenu : MonoBehaviour
{
    public void PlayGameNow()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //можно в LoadScene("имя сцены")
    }
}
