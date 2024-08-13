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
        public Health healthData;
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
            animator.SetTrigger(Hurt);
            if (healthData.currentHealth <= 0)
            {
                // Handle player death
                Die();
            }
        }

        public void Die()
        {
            animator.SetBool(Dead, true);
            Time.timeScale = 0;
            CountdownTimer countdownTimer = FindObjectOfType<CountdownTimer>();
            countdownTimer.gameOverText.SetActive(true);
        }
        

        public void Heal(int amount)
        {
            healthData.Heal(amount);
            healthBar.value = healthData.currentHealth;
        }
    }

}