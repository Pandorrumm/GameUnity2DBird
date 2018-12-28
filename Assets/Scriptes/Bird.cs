using System.Collections;
using UnityEngine;

public class Bird : Unit
{
    private Rigidbody2D rb;

    [SerializeField]
    float horizontal;//переменная для хранения значения наклона

    [SerializeField]
    private int live = 5;

    public int Live
    {
        get { return live; }
        set
        {
            if (value < 5)  //типа если изменилось кол-во жизней, обновите ui
            {
                live = value;
                lives.Refresh();
            }
        }
    }

    private Lives lives;

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
        lives = FindObjectOfType<Lives>();
        bullet = Resources.Load<Bullet>("Bullet");//откуда подгружаем. "Bullet" - назв картинки, из какой папки
    }

    void OnCollisionEnter2D(Collision2D collision) // работает с соприкосновениями
    {//если герой касается объекта с тегом Platform,
     //то скидываем скорость прыжка, что бы не разгонялся при каждом прыжке 

        if (collision.gameObject.tag == "Platform")
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 18, ForceMode2D.Impulse); //направляем его вверх
        }

        if (collision.gameObject.tag == "DeadPlatform") //смертельная платформа
        {
            rb.velocity = Vector2.zero;          
        }
   
    }
    private void Shoot()
    {
       Vector3 position = transform.position;
       Bullet newBullet= Instantiate(bullet, position, bullet.transform.rotation) as Bullet; //создание пули
       newBullet.Parent = gameObject;
       newBullet.Direction=newBullet.transform.right*(faceRight? 1.0F :-1.0F);//стреляет в зависимости от направления птички

    }

    public override void ReceiveDamage() // отнимается жизнь. override - переопределили метод
    {
        Live--;
        rb.velocity = Vector3.zero; // обнуляем ускорение
        rb.AddForce(transform.up* 17.0F, ForceMode2D.Impulse); // при касании противника подлетает вверх
        Debug.Log(Live); //кол-во жизней в консоли оставшиеся
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.gameObject.GetComponent<Bullet>(); // столкновение героя с врагом
        if (bullet&&bullet.Parent!=gameObject)  //если пулю запустил не герой
        {
            ReceiveDamage();
        }

    }
}
