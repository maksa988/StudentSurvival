using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum CharState
{
    Idle,
    Run,
    Jump
}

public class Character : Unit
{
    [SerializeField]
    private int sleep = 5;
    [SerializeField]
    private int intelligence = 5;

    [SerializeField]
    public float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;

    private GameObject invtenory;
    private bool isGrounded = false;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int) value); }
    }

    private BulletLab bullet;

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private Text sleepText;
    private Text intelText;

    [SerializeField]
    public int Sleep
    {
        get
        {
            return this.sleep;
        }
        set
        {
            Debug.Log(value);
            this.sleep = value;
            this.sleepText.text = "Сон: " + this.sleep; 
        }
    }

    [SerializeField]
    public int Intelligence
    {
        get
        {
            return this.intelligence;
        }
        set
        {
            this.intelligence = value;
            this.intelText.text = "Інтелект: " + this.intelligence;
        }
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        this.sleepText = GameObject.FindGameObjectWithTag("HealthBarSleep").GetComponent<Text>();
        this.intelText = GameObject.FindGameObjectWithTag("HealthBarIntel").GetComponent<Text>();

        this.Sleep = this.sleep;
        this.Intelligence = this.intelligence;

        bullet = Resources.Load<BulletLab>("BulletLab");
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = CharState.Idle;

        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
        if (Input.GetButton("Action")) Action();
        if (Input.GetButtonDown("Fire1")) Shoot();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        float localSpeed = this.speed + this.sleep*0.3f;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, localSpeed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;

        if (isGrounded) State = CharState.Run;
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 1.5F;
        BulletLab newBullet = Instantiate(bullet, position, bullet.transform.rotation) as BulletLab;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Action()
    {
        foreach(GameObject other in GameObject.FindGameObjectsWithTag("TeleportEnters"))
        {
            Teleport teleport = other.GetComponent<Teleport>();

            if (teleport.NearDoors)
            {
                if (!teleport.IsAvaliable)
                    GameObject.FindGameObjectWithTag("DoorStatusText").GetComponent<Text>().text = "Locked";
                else
                    GameObject.FindGameObjectWithTag("DoorStatusText").GetComponent<Text>().text = "Avaliable";

                
                teleport.Activate(transform);
            }
        }
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharState.Jump;
    }

    public override void ReceiveDamage()
    {
        this.Intelligence--;

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);
        
        if(this.Intelligence <= 0)
        {
            //Loose
            Destroy(gameObject);
        }

        Debug.Log(this.Intelligence);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        Debug.Log(collider.tag);
        if (collider.tag == "BulletLab")
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }
}