using System;
using System.Collections;
using System.Collections.Generic;
using GD.My_Game_Project.My_Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GD.My_Game_Project.My_Assets.Scripts.HealthSystem
{
    public class PlayerHealthBehavior : MonoBehaviour
    {
        public PlayerHealth healthData;
        public Slider healthBar;
        Animator animator;
        const string Hurt = "GotHit";
        const string Dead = "Dead";
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        private void Start()
        {
            healthData.Initialize();
            healthBar.maxValue = healthData.maxHealth;
            healthBar.value = healthData.currentHealth;
        }

        void Update()
        {
            healthBar.value = healthData.currentHealth;
        }
        
        public void TakeDamage(int damage)
        {
            healthData.TakeDamage(damage);
            healthBar.value = healthData.currentHealth;
            animator.SetBool(Hurt, true);
            if (healthData.currentHealth <= 0)
            {
                // Handle player death
                animator.SetBool(Dead, true);
                Die();
            }
        }

        public void Die()
        {
            animator.SetBool(Dead, true);
            Managers.GameManager.Instance.GameOver();
        }
        public void Heal(int amount)
        {
            Debug.Log("Healing player");
            healthData.Heal(amount);
            healthBar.value = healthData.currentHealth;
        }
    }

}