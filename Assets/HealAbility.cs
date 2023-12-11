using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu]
public class HealAbility : AbilityScriptableObject
{
    public float healAmount;

    public override void Activate(GameObject obj)
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (GameManager.instance.manager.shopItems[3, 1] > 0)
        {
            GameManager.instance.Heal(10);
            Debug.Log("Heal");

            GameManager.instance.manager.shopItems[3, 1]--;
        }
    }

}
