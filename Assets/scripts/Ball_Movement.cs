using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_Movement : MonoBehaviour
{
    public float moveSpeed;
    public float projectileSpeed;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;

    public ProjectileBehaviour projectile;
    public Transform launchOffset;

    private Vector2 moveDirection;
    private Vector2 mousePos;
    
    private bool alive;
    private bool hasBall;
    
    void Awake()
    {
        cam = (Camera) GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera)); 
    }
    void Start()
    {
        alive = true;
        hasBall = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
            ProcessInputs();
        }
        
    }
    void FixedUpdate()
    {
        if(alive)
        {
            //Physics Caclualtions
            Move();
            Fire();
        }
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        //.normalized negates faster diagonal movment
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetButtonDown("Fire1") && hasBall == true)
        {
            hasBall = false;
            Shoot();
        }
    }

    void Move()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
    void Fire()
    {
        Vector2 fireDir = mousePos - rb.position;
        float angle = Mathf.Atan2(fireDir.y,fireDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    void Shoot()
    {
        ProjectileBehaviour ball = Instantiate(projectile, launchOffset.position, launchOffset.rotation);
        Rigidbody2D rbBall = ball.GetComponent<Rigidbody2D>();
        rbBall.AddForce(launchOffset.up * projectileSpeed, ForceMode2D.Impulse);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Enemy")
        {
            alive = false;
            animator.SetBool("dying",true);
            moveSpeed = 0f;
            transform.localEulerAngles = new Vector3 (0f,0f,0f);
            Debug.Log("DEAD!");

            FindObjectOfType<WinLose>().Lose();
        }
        else if(other.gameObject.name == "sod(Clone)")
        {
            hasBall = true;
            Debug.Log("KILL THE CAT!");
        }
    }


}
