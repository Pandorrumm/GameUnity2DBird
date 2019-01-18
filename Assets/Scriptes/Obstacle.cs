using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider ) // касается ли что то триггера проверка
    {
        Unit unit = collider.GetComponent<Unit>();// проверка Юнит это или нет

        if(unit && unit as Bird)
        {
            unit.ReceiveDamage(); // если меня коснулся юнит, игрок - то получай урон
        }
    }	
}
