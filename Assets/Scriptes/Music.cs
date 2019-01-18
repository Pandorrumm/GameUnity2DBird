using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Slider volume;
    static AudioSource myMusic;
    public static AudioClip jumpSound, fireSound, damageSound,eggSound, liveSound, 
                            deathSound, winSound, destroyEnemySound;

    private void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");
        fireSound = Resources.Load<AudioClip>("Fire");
        damageSound= Resources.Load<AudioClip>("Damage");
        eggSound = Resources.Load<AudioClip>("Egg");
        liveSound = Resources.Load<AudioClip>("Live");
        deathSound = Resources.Load<AudioClip>("Death");
        winSound = Resources.Load<AudioClip>("Win");
        destroyEnemySound = Resources.Load<AudioClip>("DestroyEnemy");

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
            case "Egg":
                myMusic.PlayOneShot(eggSound);
                break;
            case "Live":
                myMusic.PlayOneShot(liveSound);
                break;
            case "Death":
                myMusic.PlayOneShot(deathSound);
                break;
            case "Win":
                myMusic.PlayOneShot(winSound);
                break;
            case "DestroyEnemy":
                myMusic.PlayOneShot(destroyEnemySound);
                break;
        }
    }
}
