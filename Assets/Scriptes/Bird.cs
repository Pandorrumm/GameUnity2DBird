using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Bird : Unit
{
    private Rigidbody2D rb;

    [SerializeField]
    float horizontal;//переменная для хранения значения наклона

    [SerializeField]
    private float speed = 3.0F;

    [SerializeField]
    private int live = 5;

    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded = false;

    private Animator animator;

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

    private SpriteRenderer sprite; // для flip игрока

    private float dirX;

    public GameObject gameOverText, winText, restartButton, restartButtonWin;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>(); // Children - так как дочерний от Bird
        lives = FindObjectOfType<Lives>();
        bullet = Resources.Load<Bullet>("Bullet");//откуда подгружаем. "Bullet" - назв картинки, из какой папки
    }

    void Start()
    {
        winText.SetActive(false);
        gameOverText.SetActive (false);
        restartButton.SetActive(false);
        restartButtonWin.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Run()
    {
        //dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        dirX = Input.GetAxis("Horizontal");
        //Vector3 direction = transform.right*CrossPlatformInputManager.GetAxis("Horizontal"); // направление движения

        //// Откуда, куда и какое расстояние
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        // sprite.flipX = dirX < 0.0F; // поворот персонажа при движении
    }

    private void Jump()
    {
       
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        
    }

    private void ChekGrounded() // проверка на земле или нет, т.е. есть ли другой коллайдер внизу
    {
        // OverlapCircleAll - проверяет в своём радиусе то, что необходимо, всё что попадет вернёт
        // в массиве Collider2D[]   

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F); //0.3F - радиус проверки

        isGrounded = colliders.Length > 1; 
    }

    
    private void FixedUpdate()
    {

        ChekGrounded();
        
        if (faceRight == false && dirX > 0)//moveX>0 - двигаемся вправо
        {
            Flip();
        }
        else if (faceRight == true && dirX < 0)// двигаемся влево и смотри вправо
        {
            Flip();
        }
        //если запущена игра узнаем значение наклона телефона 
        //if (Application.platform == RuntimePlatform.Android) // если запущена на андройде
        //{
        //    horizontal = Input.acceleration.x;
        //}
        //else //если ПК
        //{
        //    horizontal = Input.GetAxis("Horizontal");
        //}
        rb.velocity = new Vector2 (dirX * speed, rb.velocity.y);

        //moveInput = Input.GetAxis("Horizontal");           

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
        Run();
        // if (CrossPlatformInputManager.GetButton("Horizontal")) ; 
        if (isGrounded && Input/*CrossPlatformInputManager*/.GetButtonDown("Jump")) Jump(); //если на земле и нажимаем пробел, то прыгаем

        if(Input/*CrossPlatformInputManager*/.GetButtonDown("Fire1")) //если клавиша нажата то стреляем
        {
            Shoot();
        }
    }

   
    void OnCollisionEnter2D(Collision2D collision) // работает с соприкосновениями
    {//если герой касается объекта с тегом Platform,
     //то скидываем скорость прыжка, что бы не разгонялся при каждом прыжке 

        if (collision.gameObject.tag == "Platform")
        {       
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 16, ForceMode2D.Impulse); //направляем его вверх

            Music.PlaySound("Jump");
        }

        //if (collision.gameObject.tag == "DeadPlatform") //смертельная платформа
        //{
        //    rb.velocity = Vector2.zero;          
        //}

        if (collision.transform.tag == "MovePlatform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovePlatform")
        {
            transform.parent = null;
        }
    }

    private void Shoot()
    {
       Music.PlaySound("Fire");

       Vector3 position = transform.position;
       position.y += 0.8F; // поднимаем её чутка, что бы не из ног летела
       Bullet newBullet= Instantiate(bullet, position, bullet.transform.rotation) as Bullet; //создание пули
       newBullet.Parent = gameObject;
       newBullet.Direction=newBullet.transform.right*(faceRight ? 1.0F :-1.0F);//стреляет в зависимости от направления птички
    }
    
    public override void ReceiveDamage() // отнимается жизнь. override - переопределили метод
    {
        Live--;

        Music.PlaySound("Damage");

        gameObject.GetComponent<Animation>().Play("New Animation1");
        rb.velocity = Vector3.zero; // обнуляем ускорение
        rb.AddForce(transform.up* 17.0F, ForceMode2D.Impulse); // при касании противника подлетает вверх

        
        Debug.Log(Live); //кол-во жизней в консоли оставшиеся
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.gameObject.GetComponent<Bullet>(); // столкновение героя с врагом

        if (bullet && bullet.Parent != gameObject)  //если пулю запустил не герой
        {
            ReceiveDamage();
        }

        if (Live == 0)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }

        if (ScoreEgg.scoreAmount == 0)
        {
            winText.SetActive(true);
            restartButtonWin.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
