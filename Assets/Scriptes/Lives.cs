using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    private Transform[] hearts=new Transform[5];
    private Bird bird;

    private void Awake()
    {
        bird = FindObjectOfType<Bird>();

        for(int i=0;i<hearts.Length;i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < bird.Live)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

}
