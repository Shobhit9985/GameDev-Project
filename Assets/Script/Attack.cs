using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    public float punchDamage = 20f;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Meele();
        }
        
    }

    void Meele()
    {
        RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, enemyLayer))
            {
                // Check if the hit object has an EnemyController script
                EnemyController enemy = hit.collider.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    // Deal damage to the enemy
                    enemy.TakeDamage(punchDamage);
                }
            }
    }
}
