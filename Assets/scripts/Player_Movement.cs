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

    private Vector2 moveDirection;
    private Vector2 mousePos;
    
    private bool alive;
    private bool jump = false;
    private bool hasBall;
    
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
            hasBall = true;
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
        ProjectileBehaviour ball = Instantiate(projectile, launchOffset.position, launchOffset.rotation);
        Rigidbody2D rbBall = ball.GetComponent<Rigidbody2D>();
        rbBall.AddForce(launchOffset.right * projectileSpeed, ForceMode2D.Impulse);
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
