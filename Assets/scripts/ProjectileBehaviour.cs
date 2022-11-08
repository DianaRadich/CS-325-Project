using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4.7f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
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
