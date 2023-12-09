using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text coinText; // Reference to the Text object on the Canvas
    private int coinCount = 0;

    // This function is called when the player collects a coin
    public void CollectCoin()
    {
        coinCount++;
        UpdateCoinText();
    }

    // Update the coin count on the UI Text
    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount;
    }
}
