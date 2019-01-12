using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bird bird = collider.GetComponent<Bird>();
        
        if (bird)
        {
            Music.PlaySound("Live");
            bird.Live++;
            Destroy(gameObject);
        }
    }
}
