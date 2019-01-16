using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject deadSplash;
	public virtual void ReceiveDamage()// получение урона
    {       
        Die();
    }

    protected virtual void Die()
    {
        Instantiate(deadSplash, transform.position, Quaternion.identity);
        Music.PlaySound("DestroyEnemy");
        Destroy(gameObject);
    }
}
