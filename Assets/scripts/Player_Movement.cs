using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public float moveSpeed = 40f;
    public float projectileSpeed;
    public float horizontalMove = 0f;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;

    public ProjectileBehaviour projectile;
    public Transform launchOffset;
  
    public GameObject ballPrefab;
    //public GameObject shield;

    private Vector2 moveDirection;
    private Vector2 mousePos;
    
    private bool alive;
    private bool jump = false;
    public bool hasBall;
    public bool shieldActive = false;
    
    void Start()
    {
        alive = true;
        hasBall = true;
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;   
        
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if(Input.GetButtonDown("Fire1") && hasBall == true)
        {
            hasBall = false;
            ballPrefab.GetComponent<ProjectileBehaviour>().hasBall = false;
            launchOffset.gameObject.SetActive(false);
            Shoot();
        }
    }
    void FixedUpdate()
    {
        //Physics Caclualtions
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }

    void Aim()
    {
        Vector2 fireDir = mousePos - rb.position;
        float angle = Mathf.Atan2(fireDir.y,fireDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    void Shoot()
    {
        // ProjectileBehaviour ball = Instantiate(projectile, launchOffset.position, launchOffset.rotation);
        // Rigidbody2D rbBall = ball.GetComponent<Rigidbody2D>();
        // rbBall.AddForce(launchOffset.right * projectileSpeed, ForceMode2D.Impulse);
        GameObject newBall = Instantiate(ballPrefab, launchOffset.position, launchOffset.rotation);
        newBall.GetComponent<Rigidbody2D>().AddForce(launchOffset.right * projectileSpeed, ForceMode2D.Impulse);
    }

    public void PickupBall(){
        if (hasBall == false)
        {
            hasBall = true;
            ballPrefab.GetComponent<ProjectileBehaviour>().hasBall = true;
            GameObject ball = GameObject.FindGameObjectsWithTag("Ball")[0]; //there should only be one
            gameObject.GetComponent<CoinInventory>().StealCoins(ball.GetComponent<CoinInventory>());
            launchOffset.gameObject.SetActive(true);
        }
    }
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Flyer") )
        {
            if (!shieldActive)
            {
                FindObjectOfType<WinOrLose>().LoseLevel();
            }
            
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // if(other.gameObject.name == "Enemy")
        // {
        //     alive = false;
        //     animator.SetBool("dying",true);
        //     moveSpeed = 0f;
        //     transform.localEulerAngles = new Vector3 (0f,0f,0f);
        //     Debug.Log("DEAD!");

        //     FindObjectOfType<WinLose>().Lose();
        // }
        // else if(other.gameObject.name == "sod(Clone)")
        // {
        //     hasBall = true;
        //     Debug.Log("KILL THE CAT!");
        // }
        //Doesnt do anything right now so its commented out

        if ((!shieldActive)&&(other.CompareTag("Zapper") || other.CompareTag("Spike")))
        {
            Destroy(gameObject);
            FindObjectOfType<WinOrLose>().LoseLevel();
        }
    }

  

}
