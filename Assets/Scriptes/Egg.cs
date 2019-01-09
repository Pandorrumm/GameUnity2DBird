using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //если произогло столкновение отнимаем одно
    {
        ScoreEgg.scoreAmount -= 1;
        Destroy(gameObject);       
    }
}
