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

    protected override void Awake()  //ссылка на папку где лежит
    {      
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start() 
    {
        direction = transform.right; // направление монстра по умолчанию
    }

    protected override void Update()
    {
       Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>(); // юнит или не юнит прыгнул

        if(unit && unit is Bird)
        { 
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.1F) //проверяем с какой стороны прыжок на него, с верху или с боку. по модулю
            {
                ReceiveDamage();
            }
            else
                unit.ReceiveDamage();
        }
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 2F, 0.2F); //0.2 - радиус. direction.x*2F уменьшили зазор м/у чудищем и препятствием
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<CharacterController>())) // если что то попалось
        {
            direction *= -1;  // переворачиваем монстра
        }
        
       // if (colliders.Length == 0 )// если пустота
      //  {
       //     direction *= -1;  // переворачиваем монстра
       // }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
