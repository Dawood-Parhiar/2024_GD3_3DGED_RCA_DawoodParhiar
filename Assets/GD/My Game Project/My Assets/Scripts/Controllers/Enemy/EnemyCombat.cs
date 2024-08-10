// EnemyCombat.cs
using System;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    Animator animator;
    const string Hurt = "GotHit";
    const string isDead = "isDead";
    
    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int attackDamage = 20;
    
    [Header("Health")]
    [SerializeField] private Health enemyHealth;
    [SerializeField] private GameEvent enemyAttackEvent;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, attackPoint.position) <= attackRange)
        {
            Attack();
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth.TakeDamage(damage);
        animator.SetBool(Hurt, true);
        if (enemyHealth.currentHealth <= 0)
        {
            // Handle enemy death
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool(isDead,true);
        
        // Disable the enemy
        GetComponent<Collider>().enabled = false;// Disable the collider so that the player can't attack the enemy
        this.enabled = false;
    }
    
    void Attack()
    {
        Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
        animator.SetBool("Attacking", true);
        foreach (Collider player in hitPlayers)
        {
            enemyAttackEvent?.Raise();
            player.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         enemyAttackEvent?.Raise();
    //         PlayerCombat playerCombat = other.gameObject.GetComponent<PlayerCombat>();
    //         playerCombat.TakeDamage(10);
    //     }
    // }
}