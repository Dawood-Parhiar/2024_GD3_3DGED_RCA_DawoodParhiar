using GD;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    
    [Header("Patrol Points")]
    public Transform[] patrolPoints;
    private int currentPatrolPoint = 0;
    public float followRadius = 5f;
    private bool isFollowingPlayer = false;
    
    [SerializeField]
    private GameEvent EnemyAttackEvent;
    [Header("Animations")]
    Animator animator;
    const string WALK = "Walk";
    const string ATTACK = "Attack";
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerController>().transform;
        animator = GetComponent<Animator>();

    }
    
    void OnEnable()
    {
        EnemyAttackEvent.RegisterListener(gameObject.AddComponent<GameEventListener>());
    }
        
    
    void OnDisable()
    {
        EnemyAttackEvent.UnregisterListener(gameObject.AddComponent<GameEventListener>());
    }
    
    public void OnPlayerAttack()
    {
        Debug.Log("Player attack event received by Enemy.");
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= followRadius)
        {
            isFollowingPlayer = true;
        }
    }
    // Update is called once per frame
    void Update()
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
        
        SetAnimations();
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