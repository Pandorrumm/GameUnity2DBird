using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreEgg : MonoBehaviour
{
    public static int scoreAmount;
    Text scoreText;
    
    void Start ()
    {    
        scoreText = GetComponent<Text>();
        scoreAmount = 10;
    }
	
	void Update ()
    {
        scoreText.text =""+ scoreAmount;       
    }
}
