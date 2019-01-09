
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    public Slider volume;
    public AudioSource myMusic;
	
	void Update ()
    {
        myMusic.volume = volume.value;
	}

    //void Awake()
    //{
    //    DontDestroyOnLoad(transform.gameObject);
    //}
}
