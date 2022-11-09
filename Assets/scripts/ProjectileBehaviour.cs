using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4.7f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
        //can this be replaced by just altering ball weight, gravity, and launch speed?
        //seems like it just gives a vertical lift to the ball, kind of like a glide effect.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
           
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject.name == "Enemy")
        {
            Destroy(gameObject);
            Destroy(hitInfo.gameObject);
            FindObjectOfType<WinLose>().Win();
        }
    }
}
