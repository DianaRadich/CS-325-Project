using UnityEngine;


public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4.7f;
    public PowerupManager.Powerups powerup = PowerupManager.Powerups.None;
    public bool hasBall = true;

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.up * Time.deltaTime * speed;
        //can this be replaced by just altering ball weight, gravity, and launch speed?
        //seems like it just gives a vertical lift to the ball, kind of like a glide effect.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        PowerupScript PS = collision.collider.GetComponent<PowerupScript>();
        if(PS != null){
            powerup = PS.powerup;
        }
        //if(collision.collider.gameObject.name == "Goals")
        if(collision.collider.CompareTag("Goal"))
        {
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
            FindObjectOfType<WinOrLose>().WinLevel();
        }
        if (collision.collider.CompareTag("Player"))
        {
            Player_Movement player = collision.collider.GetComponent<Player_Movement>();
            if (!player.hasBall)
            {
                collision.collider.GetComponent<PowerupManager>().GetPowerUp(powerup);
                Destroy(gameObject);
            }
        }
        if(!hasBall && (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Flyer")) )
        {
            Destroy(collision.collider.gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PowerupScript PS = hitInfo.GetComponent<PowerupScript>();


        if (!hasBall)
        {
            if (PS != null)
            {
                powerup = PS.powerup;
            }
            if (hitInfo.gameObject.name == "Enemy")
            {
                Destroy(gameObject);
                Destroy(hitInfo.gameObject, 0.1f);
                FindObjectOfType<WinLose>().Win();
            }
            if (hitInfo.CompareTag("Player"))
            {
                hitInfo.GetComponent<PowerupManager>().GetPowerUp(powerup);
            }
        }
        if (hitInfo.CompareTag("BlackHole") || hitInfo.CompareTag("Spike"))
        {
            Destroy(gameObject);
            FindObjectOfType<WinOrLose>().LoseLevel();
        }
    }
}
