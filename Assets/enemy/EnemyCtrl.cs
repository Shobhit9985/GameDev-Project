using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    // todo : add walk, hit, sword sounds 
    //requires animation rigging package

    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public float startWaitTime = 4;
    public float timeToRotate = 2;
    public float speedWalk = 6;
    public float speedRun = 9;

    public float viewRadius = 15;
    public float viewAngle = 90;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public int health = 5;
    public bool isAlive = true;
    private Collider myCollider;
    private AudioSource audioSource;
    public AudioClip[] sounds;

    public Transform[] waypoints;
    public GameObject sword;
    private AudioSource swordAudio;
    int m_CurrentWaypointIndex;


    Vector3 playerLastPosition = Vector3.zero;
    Vector3 m_PlayerPosition;

    float m_WaitTime;
    float m_TimeToRotate;
    bool m_playerInRange;
    bool m_PlayerNear;
    bool m_IsPatrol;
    bool m_CaughtPlayer;

    private Animator animator;

    void Start()
    {
        m_PlayerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_playerInRange = false;
        m_PlayerNear = false;
        m_WaitTime = startWaitTime;
        m_TimeToRotate = timeToRotate;

        m_CurrentWaypointIndex = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        swordAudio = sword.GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        myCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        EnviromentView();
        if (!isAlive)
        {
            Destroy(this);
        }
        if (!m_IsPatrol)
        {
            
            Chasing();
            

        }
        else
        {
           
            Patroling();

        }
    }

    private void Chasing()
    {

        m_PlayerNear = false;
        playerLastPosition = Vector3.zero;

        if (!m_CaughtPlayer)
        {
            Move(speedRun);
            navMeshAgent.SetDestination(m_PlayerPosition);
          
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (m_WaitTime <= 0 && !m_CaughtPlayer && Vector3.Distance(transform.position, player.transform.position) >= 6f)
            {
                //  Check if the enemy is not near to the player, returns to patrol after the wait time delay
                m_IsPatrol = true;
                m_PlayerNear = false;
                Move(speedWalk);
                m_TimeToRotate = timeToRotate;
                m_WaitTime = startWaitTime;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
               
                
            }
            else
            {
                CaughtPlayer();
                if (Vector3.Distance(transform.position, player.transform.position) >= 2.5f)
                    //  Wait if the current position is not the player position
                    Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
        else
        {
            m_CaughtPlayer = false;
        

        }
    }

    private void Patroling()
    {
        if (m_PlayerNear)
        {
            //  Check if the enemy detected near the player, so the enemy will move to that position
            if (m_TimeToRotate <= 0)
            {
                Move(speedWalk);
                LookingPlayer(playerLastPosition);
            }
            else
            {
                //  The enemy wait for a moment and then go to the last player position
                Stop();
                m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            m_PlayerNear = false;
            playerLastPosition = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {

                if (m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    m_WaitTime = startWaitTime;
                }
                else
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }

    public void NextPoint()
    {
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }

    void Stop()
    {
        if (navMeshAgent.isStopped != true)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            animator.Play("Idle", 0, 0f);
            navMeshAgent.isStopped = true;
            navMeshAgent.speed = 0;

          
        }

    }

    void Move(float speed)
    {
        if (navMeshAgent.isStopped != false)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            animator.Play("Sword And Shield Run", 0, 0f);
            navMeshAgent.isStopped = false;
            navMeshAgent.speed = speed;

          
        }

    }

    void CaughtPlayer()
    {
        if (m_CaughtPlayer != true)
        {
           
            m_CaughtPlayer = true;
            StartCoroutine(WaitForAttack());
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

    }

    IEnumerator WaitForAttack()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
        transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        animator.Play("Attack", 0, 0f);
        swordAudio.clip = sounds[0];
        swordAudio.Play();
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;
        m_CaughtPlayer = false;
    }

    void LookingPlayer(Vector3 player)
    {
      
        navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 3)
        {
          
            if (m_WaitTime <= 0)
            {
                m_PlayerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }

    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_playerInRange = true;
                    m_IsPatrol = false;
                }
                else
                {
                    //If the player is behind a obstacle the player position will not be registered

                    m_playerInRange = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                /*
                 *  If the player is further than the view radius, then the enemy will no longer keep the player's current position.
                 *  Or the enemy is a safe zone, the enemy will no chase
                 * */
                m_playerInRange = false;

            }
            if (m_playerInRange)
            {

                //If the enemy no longer sees the player, then the enemy will go to the last position that has been registered
                   
                m_PlayerPosition = player.transform.position;

            }
        }
    }
    public void IsHit()
    {
        if (health > 0)
        {
            Debug.Log("enemy hit");
            health--;
            swordAudio.clip = sounds[1];
            swordAudio.Play();
        }

        if (health == 0)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            myCollider.enabled = false;
            Debug.Log("enemy dead");
            isAlive = false;
            animator.Play("Death", 0, 0f);
        }
    }
}
