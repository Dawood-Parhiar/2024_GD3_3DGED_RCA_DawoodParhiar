using System;
using System.Collections;
using System.Collections.Generic;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    // this script is sourced from https://www.youtube.com/watch?v=LVu3_IVCzys
    // and is used to control the player character using the NavMeshAgent component
    // and the PlayerInput component
    
    
    const string IDLE = "Idle";
    const string RUN = "Run";
    const string ATTACK = "Attack";
    
    PlayerInput input;
    [SerializeField]
    private GameEvent PlayerAttackEvent;
    
    NavMeshAgent agent;
    Animator animator;

    [Header("Health")]
    [SerializeField] private Health playerHealth;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    float lookRotationSpeed = 8f;
    bool playerBusy = false;
    GameObject target;
    
    void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        input = new PlayerInput();
        AssignInputs();
    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
        input.Main.Attack.performed += ctx => Attack();
        
    }

    public void Attack()
    {
        if (!playerBusy)
        {
            playerBusy = true;
            animator.Play(ATTACK);
            StartCoroutine(ResetPlayerBusy());
            PlayerAttackEvent?.Raise(); // null conditional operator to check if the event is null before raising it 
            Debug.Log("Player attack event raised.");
        }
    }

    private IEnumerator ResetPlayerBusy()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        playerBusy = false;
    }

    void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers)) 
        {
            target = null;
            agent.destination = hit.point;
            if(clickEffect != null)
            { Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
        }
    }

    void OnEnable() 
    { input.Enable(); }

    void OnDisable() 
    { input.Disable();}

    void Update() 
    {
        FaceTarget();
        SetAnimations();
    }

    void FaceTarget()
    {
        if(agent.destination == transform.position) return;
        
           Vector3 facing = Vector3.zero;
           if(target != null)
           { facing = target.transform.position; }
           else
           { facing = agent.destination; }
        
        Vector3 direction = (agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed); 
    }

    void SetAnimations()
    {
        
        if (agent.velocity == Vector3.zero)
        {
            animator.Play(IDLE);
        }
        else
        {
            animator.Play(RUN);
        }
    }

    public void TakeDamage(int damage)
    {
        
        if (playerHealth.currentHealth <= 0)
        {
            //Handle player death
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        Enemy enemy;
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(20);
        }

    }
}

