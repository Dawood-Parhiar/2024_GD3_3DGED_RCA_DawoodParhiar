using System;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using GD.My_Game_Project.My_Assets.Scripts.Controllers.Character;
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
    public bool isFollowingPlayer = false;
    [Header("Animations")]
    private Animator animator;
    const string WALK = "Walking";
    const string ATTACK = "Attack";
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;
        animator = GetComponent<Animator>();
        
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
            agent.SetDestination(player.position);
        }
        else
        {
            if (isFollowingPlayer)
            {
                isFollowingPlayer = false;
                goToNextPatrolPoint();
            }

            if (!agent.pathPending && agent.remainingDistance < 0.5)
            {
                goToNextPatrolPoint();
            }
        }
    }

    private void goToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;
        // Set the agent to go to the next patrol point
        agent.destination = patrolPoints[currentPatrolPoint].position;
        currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
    }

    void SetAnimations()
   {
       // Check if the enemy is walking
       bool isWalking = agent.velocity != Vector3.zero;
         animator.SetBool(WALK, isWalking);
   }
}