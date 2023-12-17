using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform playerTransform;
    public float patrolSpeed = 2.0f;
    public float chaseSpeed = 4.0f;
    public float detectionRange = 5.0f;
    public float health = 100.0f;

    private NavMeshAgent navMeshAgent;
    private bool isChasing = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetPatrolDestination();
    }

    void Update()
    {
        if (health <= 0)
        {
            // Enemy is defeated, perform any required actions (e.g., play death animation, spawn particles, etc.)
            Destroy(gameObject);
            return;
        }

        if (IsPlayerInRange())
        {
            isChasing = true;
            SetChaseDestination();
        }
        else if (!navMeshAgent.hasPath || navMeshAgent.remainingDistance < 0.1f)
        {
            // If not currently chasing and reached destination, patrol to the other waypoint
            isChasing = false;
            SetPatrolDestination();
        }

        // If chasing, update destination to player's position
        if (isChasing)
        {
            SetChaseDestination();
        }
    }

    void SetPatrolDestination()
    {
        navMeshAgent.speed = patrolSpeed;
        navMeshAgent.SetDestination(waypoint1.position);
    }

    void SetChaseDestination()
    {
        navMeshAgent.speed = chaseSpeed;
        navMeshAgent.SetDestination(playerTransform.position);
    }

    bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, playerTransform.position) < detectionRange;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        // Perform any visual/audio feedback for taking damage (e.g., play a hit animation, display a health bar, etc.)
    }
}
