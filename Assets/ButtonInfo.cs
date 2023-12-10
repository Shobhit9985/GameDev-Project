using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TMPro.TextMeshProUGUI PriceTxt;
    public TMPro.TextMeshProUGUI QuantityTxt;
    public GameObject shopManager;

    private void Update()
    {
        PriceTxt.text = "Price: $ " + shopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID];
        QuantityTxt.text = shopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();

    }


}
