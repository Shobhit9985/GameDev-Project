using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public AbilityScriptableObject ability;
    float cooldownTime;
    float activeTime;
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;
    public KeyCode key;

    // Update is called once per frame
    void Update()
    {
        if (state == AbilityState.ready)
        {
            if(Input.GetKeyDown(key))
            {
                ability.Activate(gameObject);
                state = AbilityState.active;
                activeTime = ability.activeTime;
            }

        }
        if (state == AbilityState.active)
        {
            if(activeTime>0)
            {
                activeTime -= Time.deltaTime;
            }
            else
            {
                state = AbilityState.cooldown;
                cooldownTime = ability.cooldownTime;
            }

        }
        if(state == AbilityState.cooldown)
        {
            if (cooldownTime > 0)
            {
                cooldownTime -= Time.deltaTime;
            }
            else
            {
                state = AbilityState.ready;
                
            }

        }
        
    }
}
