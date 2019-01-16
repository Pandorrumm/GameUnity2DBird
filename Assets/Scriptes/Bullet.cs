using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject parent; //кто запустил пулю
    public GameObject Parent { set { parent = value; } get { return parent; } } // доступ 

    [SerializeField]
    private float speed = 7.0F;

    private Vector3 direction; //направление полёта пули

    public Vector3 Direction { set { direction = value; } }//св-во для доступа , set -  задаётся от движения героя

    private SpriteRenderer sprite; //для доступа к цвету

    public Color Color
    {
        set { sprite.color = value; }
    }

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Destroy(gameObject,1F); //пуля через 1 секунду уничтожится
    }

    private void Update() 
    {
        // полет пули
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)//проверяем, если попала в юнит, то уничтожится
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit.gameObject!=parent) //если юнит не парент, то уничтожит себя
        {           
             Destroy(gameObject);
        }
    }
}
