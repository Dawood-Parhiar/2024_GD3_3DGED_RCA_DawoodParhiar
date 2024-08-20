using System;
using GD.My_Game_Project.My_Assets.Scripts.HealthSystem;
using GD.My_Game_Project.My_Assets.Scripts.Interfaces;
using UnityEngine;

namespace GD.My_Game_Project.My_Assets.Scripts.Controllers.Enemy
{
    public class HurtEnemy : MonoBehaviour, IDamagable
    {
        [Header("Health")]
        [SerializeField] private EnemyHealth enemyHealth;
        [SerializeField] private GameEvent enemyAttackEvent;
        
        [Header("Hurt Sound")]
        [SerializeField] private AudioSource audioSource;
        
        Animator animator;
        const string GotHit = "GotHit";
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Damage(int damageAmount)
        {
            //Debug.Log("Enemy has been damaged for " + damageAmount + " damage.");
            enemyHealth.TakeDamage(damageAmount);
            animator.SetBool(GotHit, true);
            audioSource.Play();
        }
    }
}