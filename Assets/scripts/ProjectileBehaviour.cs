using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4.7f;
    public PowerupManager.Powerups powerup = PowerupManager.Powerups.None;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
        //can this be replaced by just altering ball weight, gravity, and launch speed?
        //seems like it just gives a vertical lift to the ball, kind of like a glide effect.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        PowerupScript PS = collision.collider.GetComponent<PowerupScript>();
        if(PS != null){
            powerup = PS.powerup;
        }
        if(collision.collider.gameObject.name == "Goals")
        {
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
            FindObjectOfType<WinLose>().Win();
        }
        if(collision.collider.CompareTag("Player")){
            collision.collider.GetComponent<PowerupManager>().GetPowerUp(powerup);
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PowerupScript PS = hitInfo.GetComponent<PowerupScript>();
        if(PS != null){
            powerup = PS.powerup;
        }
        if(hitInfo.gameObject.name == "Enemy")
        {
            Destroy(gameObject);
            Destroy(hitInfo.gameObject);
            FindObjectOfType<WinLose>().Win();
        }
        if(hitInfo.CompareTag("Player")){
            hitInfo.GetComponent<PowerupManager>().GetPowerUp(powerup);
        }
    }
}
