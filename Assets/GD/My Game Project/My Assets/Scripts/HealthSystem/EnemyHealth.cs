using UnityEngine;
using UnityEngine.UI;

namespace GD.My_Game_Project.My_Assets.Scripts
{
    public class EnemyHealth : MonoBehaviour
    {
        public Health healthData;
        //public Slider healthBar;
        
        
        void Start()
        {
            if (healthData.healthBar != null)
            {
                healthData.healthBar.maxValue = healthData.maxHealth;
                healthData.healthBar.value = healthData.currentHealth;
            }
        }

        void Update()
        {
            if (healthData.healthBar != null)
            {
                Vector3 healthBarPosition = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
                healthData.healthBar.transform.position = healthBarPosition;
            }
        }

        public void TakeDamage(int damage)
        {
            healthData.TakeDamage(damage);
            UpdateHealthBar();
        }

        public void Heal(int amount)
        {
            healthData.Heal(amount);
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            if (healthData.healthBar != null)
            {
                healthData.healthBar.value = healthData.currentHealth;
            }
        }
    }
}