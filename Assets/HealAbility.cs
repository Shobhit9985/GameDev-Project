using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealAbility : AbilityScriptableObject
{
    public float healAmount;

    public override void Activate(GameObject obj)
    {
        Movement movement = obj.GetComponent<Movement>();
        if(movement != null)
        {
            movement.health += healAmount;
            Debug.Log(movement.health);
        }

    }

}
