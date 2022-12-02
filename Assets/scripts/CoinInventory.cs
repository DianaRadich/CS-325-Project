using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinInventory : MonoBehaviour
{
    public int NumberOfCoins { get; private set; }

    public UnityEvent<CoinInventory> OnCoinCollected;
    
    public void CoinCollected()
    {
        NumberOfCoins++;
        OnCoinCollected.Invoke(this);
    }

    public int getNumCoins()
    {
        return NumberOfCoins;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}