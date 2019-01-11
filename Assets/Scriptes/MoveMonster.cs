using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveMonster : Monster
{
    [SerializeField]
    private float speed = 2.0F;

    private Vector3 direction;

    private SpriteRenderer sprite;

    [SerializeField]
    private int liveMoveMonster = 5;

    protected override void Awake()  //ссылка на папку где лежит
    {      
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start() 
    {
        direction = transform.right; // направление монстра по умолчанию в право
    }

    protected override void Update()
    {
       Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>(); //косание Триггера с пулей

        if (bullet) // если это пуля,то
        {
            liveMoveMonster--;
            Debug.Log(liveMoveMonster);

            if (liveMoveMonster == 0)
            {
                ReceiveDamage();
            }
        }

        Bird bird = collider.GetComponent<Bird>(); // юнит или не юнит прыгнул

        if (bird) 
        {
            bird.ReceiveDamage();
        }
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.right * direction.x*3F , 0.5F); //0.2 - радиус. direction.x*4F уменьшили зазор м/у чудищем и препятствием

        if (colliders.Length == 1 && colliders.All(x => !x.GetComponent<Bird>())) // если что то попалось.
        {
            direction *= -1.0F;  //  монстр идёт в другую сторону
        }
     
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
