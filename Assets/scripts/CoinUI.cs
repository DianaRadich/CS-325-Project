using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;
    //private TextMeshProUGUI winText;
    // Start is called before the first frame update
    
    public void UpdateCoinText(CoinInventory coinInventory)
    {
        coinText.text = "Coins: " + coinInventory.NumberOfCoins.ToString();
    }


    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

}
