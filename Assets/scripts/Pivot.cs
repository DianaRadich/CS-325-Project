using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject myPlayer;
    public GameObject ball;

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        ball.transform.localPosition = new Vector3(4.4f + Mathf.Abs(Mathf.Sin(rotationZ*Mathf.Deg2Rad)),0,0);
    }
   
}
