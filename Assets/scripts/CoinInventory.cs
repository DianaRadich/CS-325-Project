using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinInventory : MonoBehaviour
{
    public int NumberOfCoins { get; private set; }

    public UnityEvent<CoinInventory> OnCoinCollected;

    private GameObject ballCoinText;
    
    public void CoinCollected()
    {
        //Debug.Log(NumberOfCoins);
        NumberOfCoins++;
        //Debug.Log(NumberOfCoins);
        OnCoinCollected.Invoke(this);
    }

    public void StealCoins(CoinInventory victim)
    {
        //Debug.Log(NumberOfCoins);
        
        NumberOfCoins += victim.WithdrawAll();
        //Debug.Log(NumberOfCoins);
        OnCoinCollected.Invoke(this);
    }

    public int WithdrawAll()
    {
        int count = NumberOfCoins;
        NumberOfCoins = 0;
        OnCoinCollected.Invoke(this);
        return count;
    }

    public int getNumCoins()
    {
        return NumberOfCoins;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Ball")
        {
            ballCoinText = GameObject.FindGameObjectsWithTag("BallCoinText")[0]; //to obtain at runtime, there is only one
            OnCoinCollected.AddListener(ballCoinText.GetComponent<CoinUI>().UpdateCoinText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}