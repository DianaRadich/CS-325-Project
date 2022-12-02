using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public AudioClip pickup_sound;
    void Start()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        CoinInventory coinInventory = other.GetComponent<CoinInventory>();

        if (coinInventory!=null)
        {
            //Debug.Log("coinInventory was NOT null!");
            //AudioSource.PlayClipAtPoint(pickup_sound, transform.position);
            coinInventory.CoinCollected();
            gameObject.SetActive(false);
        }
        else
        {
            //Debug.Log("coinInventory was null!");
        }

    }
}
