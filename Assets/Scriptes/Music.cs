
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    public Slider volume;
    static AudioSource myMusic;
    public static AudioClip jumpSound, fireSound, damageSound;

    private void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");
        fireSound = Resources.Load<AudioClip>("Fire");
        damageSound= Resources.Load<AudioClip>("Damage");

        myMusic = GetComponent<AudioSource>();

    }

    void Update ()
    {
        myMusic.volume = volume.value;
	}

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Fire":
                myMusic.PlayOneShot(fireSound);
                break;
            case "Jump":
                myMusic.PlayOneShot(jumpSound);
                break;
            case "Damage":
                myMusic.PlayOneShot(damageSound);
                break;
        }
    }


    //void Awake()
    //{
    //    DontDestroyOnLoad(transform.gameObject);
    //}
}
