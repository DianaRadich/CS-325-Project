using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D enemy;

    public Transform leftpoint,rightpoint;
    public float Speed;
    private float leftx,rightx;

    private bool Faceleft = true;


    // Start is called before the first frame update
    void Start()
    {
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Faceleft)
        {
            enemy.velocity = new Vector2(-Speed, enemy.velocity.y);
            if(transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                Faceleft = false;
            }
        }else
        {
            enemy.velocity = new Vector2(Speed, enemy.velocity.y);
            if(transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                Faceleft = true;
            }
        }

    }
}
