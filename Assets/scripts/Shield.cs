using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float lifespan;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player_Movement>().shieldActive = true;
        Destroy(gameObject, lifespan);
    }

    void OnDestroy()
    {
        FindObjectOfType<Player_Movement>().shieldActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
