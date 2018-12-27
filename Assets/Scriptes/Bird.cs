using System.Collections;
using UnityEngine;

public class Bird : Unit
{

    private Rigidbody2D rb;
    [SerializeField]

    float horizontal;//переменная для хранения значения наклона

    private float moveInput;

    private bool faceRight = true;

    private Bullet bullet;

    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //если запущена игра узнаем значение наклона телефона 
    private void FixedUpdate()
    {

        if (Application.platform == RuntimePlatform.Android) // если запущена на андройде
        {
            horizontal = Input.acceleration.x;
        }
        else //если ПК
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 10f, rb.velocity.y);//ось y не трогаем, 10f-скорость

        moveInput = Input.GetAxis("Horizontal");           
        
        if (faceRight == false && moveInput > 0)//moveX>0 - двигаемся вправо
        {
            Flip();
        }
        else if (faceRight == true && moveInput < 0)// двигаемся влево и смотри вправо
        {
            Flip();
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //если клавиша нажата то стреляем
        {
            Shoot();
        }
    }

    private void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");//откуда подгружаем. "Bullet" - назв картинки, из какой папки
    }

    void OnCollisionEnter2D(Collision2D other) // работает с соприкосновениями
    {//если герой касается объекта с тегом Platform,
     //то скидываем скорость прыжка, что бы не разгонялся при каждом прыжке 

        if (other.gameObject.tag == "Platform")
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 20, ForceMode2D.Impulse); //направляем его вверх
        }

        if (other.gameObject.tag == "DeadPlatform") //смертельная платформа
        {
            rb.velocity = Vector2.zero;
            
        }

    }
    private void Shoot()
    {
       Vector3 position = transform.position;
       Bullet newBullet= Instantiate(bullet, position, bullet.transform.rotation) as Bullet; //создание пули

       newBullet.Direction=newBullet.transform.right*(faceRight? 1.0F :-1.0F);//стреляет в зависимости от направления птички

    }

    

}
