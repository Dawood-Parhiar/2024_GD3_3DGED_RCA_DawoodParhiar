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
    EnemyCombat enemyCombat;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;
        animator = GetComponent<Animator>();
        enemyCombat = GetComponent<EnemyCombat>();
    }
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
}