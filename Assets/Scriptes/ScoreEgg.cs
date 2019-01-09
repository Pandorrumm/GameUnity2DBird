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
        scoreAmount = 2;
    }
	
	void Update ()
    {
        scoreText.text =""+ scoreAmount;       
    }
}
