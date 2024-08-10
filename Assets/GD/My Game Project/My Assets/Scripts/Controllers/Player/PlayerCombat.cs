using System;
using System.Collections;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;
    public bool playerBusy = false;
    
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    [SerializeField] private int attackDamage;
    
    [SerializeField] private GameEvent playerAttackEvent;
    [SerializeField] private Health playerHealth;

    
    void Awake()
    { animator = GetComponent<Animator>(); }
    public void Attack()
    {
        if (!playerBusy)
        {
            Debug.Log("Attack");
            playerBusy = true;
            animator.SetTrigger("SimpleAttack");
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
               enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
               
            }
            StartCoroutine(PerformAttack());
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

    private IEnumerator PerformAttack()
    {
        playerAttackEvent?.Raise();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        playerBusy = false;
    }
    public void TakeDamage(int damage)
    {
        playerHealth.TakeDamage(damage);
        animator.SetTrigger("Hurt");
        if (playerHealth.currentHealth <= 0)
        {
            // Handle player death
            Time.timeScale = 0;
        }
    }
}