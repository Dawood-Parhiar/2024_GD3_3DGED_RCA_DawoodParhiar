// using System;
// using System.Collections;
// using GD;
// using GD.My_Game_Project.My_Assets.Scripts;
// using UnityEngine;
// using UnityEngine.Serialization;
//
// public class PlayerCombat : MonoBehaviour
// {
//     Animator animator;
//     public bool isAttacking = false;
//     
//     [SerializeField]private float damageAfterTime;
//     [SerializeField]private float strongDamageAfterTime;
//     [SerializeField]private int damage;
//     [SerializeField]private AttackArea attackArea;
//     [SerializeField] private GameEvent playerAttackEvent;
//     [SerializeField] private Health playerHealth;
//     
//
//
//     void Awake()
//     { animator = GetComponent<Animator>(); }
//
//     public void Attack()
//     {
//         if(isAttacking) return;
//         animator.SetTrigger("SimpleAttack");
//         StartCoroutine("Hit",false);
//     }
//
//     public void StrongAttack()
//     {
//         if(isAttacking) return;
//         animator.SetTrigger("StrongAttack");
//         StartCoroutine("Hit", true);
//     }
//     // public void Attack()
//     // {
//     //     if (!playerBusy)
//     //     {
//     //         Debug.Log("Attack");
//     //         playerBusy = true;
//     //         animator.SetTrigger("SimpleAttack");
//     //         Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
//     //         foreach (Collider enemy in hitEnemies)
//     //         {
//     //            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
//     //            
//     //         }
//     //         StartCoroutine(PerformAttack());
//     //     }
//     // }
//
//     // private void OnDrawGizmosSelected()
//     // {
//     //     if (attackPoint == null)
//     //         return;
//     //     Gizmos.DrawWireSphere(attackPoint.position,attackRange);
//     // }
//
//     // private IEnumerator PerformAttack()
//     // {
//     //     playerAttackEvent?.Raise();
//     //     yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
//     //     playerBusy = false;
//     // }
//
//     private IEnumerator Hit(bool strong)
//     {
//         isAttacking = true;
//         playerAttackEvent?.Raise();
//         //yield return new WaitForSeconds(strong ? strongDamageAfterTime : damageAfterTime);
//         yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
//         foreach (var attackAreaDamageable in attackArea.damagablesInRange)
//         {
//             attackAreaDamageable.Damage(damage * (strong ? 3 : 1));    
//         }
//         yield return new WaitForSeconds(strong ? strongDamageAfterTime : damageAfterTime);
//         isAttacking = false;
//
//     }
//     // public void TakeDamage(int damage)
//     // {
//     //     playerHealth.TakeDamage(damage);
//     //     animator.SetTrigger("Hurt");
//     //     if (playerHealth.currentHealth <= 0)
//     //     {
//     //         // Handle player death
//     //          WaitForSeconds(2);
//     //         Time.timeScale = 0;
//     //     }
//     // }
// }
using System.Collections;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using GD.My_Game_Project.My_Assets.Scripts.HealthSystem;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;
    public bool isAttacking = false;
    private HealthBehavior health;
    [SerializeField] private float damageAfterTime;
    [SerializeField] private float strongDamageAfterTime;
    [SerializeField] private int damage;
    [SerializeField] private AttackArea attackArea;
    [SerializeField] private GameEvent playerAttackEvent;

    void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<HealthBehavior>();
    }

    public void Attack()
    {
        if (isAttacking) return;
        animator.SetTrigger("SimpleAttack");
        StartCoroutine(nameof(Hit), false);
    }

    public void StrongAttack()
    {
        if (isAttacking) return;
        animator.SetTrigger("StrongAttack");
        StartCoroutine(nameof(Hit), true);
    }

    private IEnumerator Hit(bool strong)
    {
        isAttacking = true;
        playerAttackEvent?.Raise();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        
        if (attackArea == null)
        {
            Debug.LogError("AttackArea is not assigned!");
            yield break;
        }
        
        foreach (var attackAreaDamageable in attackArea.damagablesInRange)
        {
            attackAreaDamageable.Damage(damage * (strong ? 3 : 1));
        }
        yield return new WaitForSeconds(strong ? strongDamageAfterTime : damageAfterTime);
        isAttacking = false;
    }
}
