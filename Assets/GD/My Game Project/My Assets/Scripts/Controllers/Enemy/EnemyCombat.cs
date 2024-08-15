using System;
using System.Collections;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using GD.My_Game_Project.My_Assets.Scripts.HealthSystem;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    
    private Animator animator;
    private PlayerCombat playerCombat;
    const string ATTACK = "Attack";
    
    [Header("Attack")] 
    [SerializeField] 
    private AttackArea attackArea; 
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int attackDamage = 10;
    public float attackCooldown = 1.0f; // Cooldown between attacks
    
    EnemyMovement enemyMovement;
    
    [SerializeField] private GameEvent enemyAttackEvent;

    private float lastAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
        

    }

    private void Update()
    {
        // If the enemy is following the player and the attack cooldown has passed
        if (enemyMovement.isFollowingPlayer && Time.time >= lastAttackTime + attackCooldown)
        {
            Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
            if (hitPlayers.Length > 0)
            {
                Attack(hitPlayers);
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack(Collider[] hitPlayers)
    {   // Play the attack animation
        animator.Play(ATTACK);
        StartCoroutine(PerformAttack(hitPlayers));
    }
    
    private IEnumerator PerformAttack(Collider[] hitPlayers)
    {
        
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        foreach (Collider player in hitPlayers)
        {
            var healthComponent = player.GetComponent<PlayerHealthBehavior>();
            enemyAttackEvent?.Raise();
            healthComponent.TakeDamage(attackDamage);
        }
    }



    private void OnDrawGizmosSelected()
    {   // Draw the attack range in the editor
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}