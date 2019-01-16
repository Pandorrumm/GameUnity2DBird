using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }

    protected virtual void OnTriggerEnter2D(Collider2D collider) //virtual для наследников использовать что бы
    {
        Bullet bullet = collider.GetComponent<Bullet>(); //косание Триггера с пулей

        if (bullet) // если это пуля,то
        {
            ReceiveDamage();
        }

        Bird bird = collider.GetComponent<Bird>(); // юнит или не юнит прыгнул

        if (bird) //
        {
           bird. ReceiveDamage();
        }

    }
}
