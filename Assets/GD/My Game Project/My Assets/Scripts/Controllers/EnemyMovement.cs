using System;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    
    [Header("Patrol Points")]
    public Transform[] patrolPoints;
    private int currentPatrolPoint = 0;
    public float followRadius = 5f;
    private bool isFollowingPlayer = false;
    
    [Header("Animations")]
    Animator animator;
    const string WALK = "Walk";
    const string ATTACK = "Attack";
    //const string GotHit = "GotHit";
    
    EnemyCombat enemyCombat;
    // [Header("Health")]
    // [SerializeField] private Health enemyHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;
        animator = GetComponent<Animator>();
        enemyCombat = GetComponent<EnemyCombat>();

    }
    
    
    // public void OnPlayerAttack()
    // {
    //     Debug.Log("Enemy attack event received by Enemy.");
    //     float distanceToPlayer = Vector3.Distance(transform.position, player.position);
    //     if (distanceToPlayer <= followRadius)
    //     {
    //         isFollowingPlayer = true;
    //     }
    //     
    // }
    // public void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("Enemy collided with player.");
    //         PlayerCombat playerCombat = other.gameObject.GetComponent<PlayerCombat>();
    //         playerCombat.TakeDamage(10);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        EnemyPatrol();
        SetAnimations();
    }

    private void EnemyPatrol()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followRadius)
        {
            isFollowingPlayer = true;
            
        }
        else if (distanceToPlayer > followRadius && isFollowingPlayer)
        {
            isFollowingPlayer = false;
            agent.SetDestination(patrolPoints[currentPatrolPoint].position);
        }

        if (!isFollowingPlayer)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[currentPatrolPoint].position);
            }
        }
        else
        {
            agent.SetDestination(player.position);
        }
    }


    void SetAnimations()
   {
       if (isFollowingPlayer)
       {
           animator.Play(ATTACK);
       }
       else if (agent.velocity != Vector3.zero)
       {
           animator.Play(WALK);
       }
   }
    
    // public void TakeDamage(int damage)
    // {
    //     enemyHealth.TakeDamage(damage);
    //     animator.SetBool(GotHit, true);
    //     if (enemyHealth.currentHealth <= 0)
    //     {
    //         // Handle enemy death
    //         Destroy(gameObject);
    //     }
    // }
    
    
}