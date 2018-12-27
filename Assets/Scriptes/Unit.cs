﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public virtual void ReceiveDamage()// получение урона
    {
        Die();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
