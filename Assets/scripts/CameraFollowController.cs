using UnityEngine;

public class CameraFollowController : MonoBehaviour 
{
    public Transform target;
    public Vector3 offset;

    private void FixedUpdate()
    {
        transform.position = GameObject.FindWithTag("Player").transform.position + offset;
    }
}
