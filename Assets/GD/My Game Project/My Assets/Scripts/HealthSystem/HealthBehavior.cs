using System;
using UnityEngine;
using UnityEngine.UI;

namespace GD.My_Game_Project.My_Assets.Scripts.HealthSystem
{
    public class HealthBehavior : MonoBehaviour
    {
        public Health healthData;
        public Slider healthBar;
        Animator animator;
        private GameObject gameOverText;
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
            animator.SetTrigger("GotHit");
            
            if (healthData.currentHealth <= 0)
            {
                // Handle player death
                Die();
            }
        }

        private void Die()
        {
            animator.SetTrigger(Dead);
            Time.timeScale = 0;
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }
        }

        public void Heal(int amount)
        {
            healthData.Heal(amount);
            healthBar.value = healthData.currentHealth;
        }
    }

}