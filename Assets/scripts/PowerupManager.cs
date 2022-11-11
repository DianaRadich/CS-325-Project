using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    public enum Powerups
    {
        None,
        Dash,
        Jump,
        Shield,
        Recall
    }
    public Powerups powerup;
    public Player_Movement movmentScript;

    public Rigidbody2D rb2D;
    public float jumpForce;
    public float dashDistance;
    private Vector2 vel;
    public Animator animator;
    public ShieldSpawner shieldSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire3"))
		{
		    switch (powerup)
		    {
			    case Powerups.None:
				    break;
			    case Powerups.Dash:
                    Debug.Log("Dash");
                    //Vector2 dir = (movmentScript.launchOffset.position - transform.position).normalized;
                    //rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                    //rb2D.AddForce(dir*dashDistance);
                    Dash();
                    powerup = Powerups.None;
                    animator.SetBool("isYellow", false);
                    break;
			    case Powerups.Jump:
                    rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                    rb2D.AddForce(new Vector2(0f, jumpForce));
                    powerup = Powerups.None;
                    animator.SetBool("isBlue", false);
                    break;
			    case Powerups.Shield:
                    //movmentScript.shieldActive = true;
                    shieldSpawner.ActivateShield();
                    powerup = Powerups.None;
                    animator.SetBool("isGreen", false);
                    break;
			    case Powerups.Recall:
                    //i dont like how it looks either but thats whats going here for now
                    GameObject ball = GameObject.FindGameObjectsWithTag("Ball")[0]; //there should only be one
                    GetPowerUp(ball.GetComponent<ProjectileBehaviour>().powerup);
                    Destroy(ball);
                    animator.SetBool("isRed", false);
                    //does not set powerup because then recall wouldnt give palyer ball powerup
                    break;
			    default:
				    break;
		    }
            //set ball back to purple after power use
            animator.SetBool("isPurple", true);
            //powerup = Powerups.None; //refer to line 65 forwhy this is commented out
        }
    }

    public async void Dash()
	{
        Vector2 dir = (movmentScript.launchOffset.position - transform.position).normalized;
        Vector2 DashPos;
        Debug.DrawLine(transform.position, transform.position + (Vector3)dir * dashDistance,Color.blue,2);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dashDistance);
		if (hit)
		{
            DashPos = hit.point - dir * 2;
		}
        DashPos = ((movmentScript.launchOffset.position - transform.position).normalized * dashDistance) + transform.position;
        Vector2 startPos = transform.position;
        float t = 0;
        while (t < .1)
		{
            rb2D.position = Vector2.Lerp(startPos, DashPos, t*10);
            rb2D.velocity = rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            await Task.Yield();
            t += Time.deltaTime;
		}
        rb2D.velocity = rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
    }

    public void GetPowerUp(Powerups power){
        movmentScript.PickupBall();

		if(power != Powerups.None){
            powerup = power;
        }

        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
        switch (powerup)
        {
            case PowerupManager.Powerups.None:
                animator.SetBool("isPurple", true);
                break;
            case PowerupManager.Powerups.Jump:
                animator.SetBool("isBlue", true);
                break;
            case PowerupManager.Powerups.Dash:
                animator.SetBool("isYellow", true);
                break;
            case PowerupManager.Powerups.Shield:
                animator.SetBool("isGreen", true);
                break;
            case PowerupManager.Powerups.Recall:
                animator.SetBool("isRed", true);
                break;
        }


    }
}
