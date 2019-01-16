using UnityEngine;

public class ShootMonsterLeft : Monster
{
    [SerializeField]
    private float rate = 2.0F; // частота стрельбы

    [SerializeField]
    private Color bulletColor = Color.white; //базовый цвет

    private Bullet bullet;

    protected override void Awake()  //ссылка на папку где лежит пуля
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        Vector3 position = transform.position;  // позиция пули
        position.y += 0.5F;

        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject; //Parent пули это мы 
        newBullet.Direction = - newBullet.transform.right; // направление -если влево то минус newBullet.transform.right;

        newBullet.Color = bulletColor; // для цвета
    }

    protected override void OnTriggerEnter2D(Collider2D collider) //virtual для наследников использовать что бы
    {
        Unit unit = collider.GetComponent<Unit>(); // юнит или не юнит прыгнул

        if (unit && unit is Bird)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 1F) //проверяем с какой стороны прыжок на него, с верху или с боку. по модулю
            {
                ReceiveDamage();
            }
            else
                unit.ReceiveDamage();
        }
    }
}
