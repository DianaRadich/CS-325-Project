using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    public GameObject shieldPrefab;
    
    public void ActivateShield()
    {
        GameObject shield = Instantiate(shieldPrefab, gameObject.transform.position, gameObject.transform.rotation);
        shield.transform.SetParent(gameObject.transform);
        //Destroy(shield, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
