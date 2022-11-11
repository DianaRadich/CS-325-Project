using System.Collections;
using System.Collections.Generic;
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

				    break;
			    case Powerups.Jump:

				    break;
			    case Powerups.Shield:
                    //movmentScript.shieldActive = true;
                    shieldSpawner.ActivateShield();
                    powerup = Powerups.None;
				    break;
			    case Powerups.Recall:
                    //i dont like how it looks either but thats whats going here for now
                    GameObject ball = GameObject.FindGameObjectsWithTag("Ball")[0]; //there should only be one
                    GetPowerUp(ball.GetComponent<ProjectileBehaviour>().powerup);
                    Destroy(ball);
				    break;
			    default:
				    break;
		    }
            
		}
    }

    public void GetPowerUp(Powerups power){
        movmentScript.PickupBall();

		if(power != Powerups.None){
            powerup = power;
        }
        
    }
}
