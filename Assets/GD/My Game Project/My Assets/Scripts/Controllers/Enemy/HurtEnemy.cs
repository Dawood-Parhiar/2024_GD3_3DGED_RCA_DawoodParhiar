using System;
using GD.My_Game_Project.My_Assets.Scripts.Controllers.Interfaces;
using UnityEngine;

namespace GD.My_Game_Project.My_Assets.Scripts.Controllers.Enemy
{
    public class HurtEnemy : MonoBehaviour, IDamagable
    {
        [Header("Health")]
        [SerializeField] private Health enemyHealth;
        [SerializeField] private GameEvent enemyAttackEvent;
        
        Animator animator;
        const string Hurt = "GotHit";
        const string isDead = "isDead";
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Damage(int damageAmount)
        {
            //Debug.Log("Enemy has been damaged for " + damageAmount + " damage.");
            animator.SetTrigger("GotHit");
            enemyHealth.TakeDamage(damageAmount);
            animator.SetBool(Hurt, true);
        }
    }
}