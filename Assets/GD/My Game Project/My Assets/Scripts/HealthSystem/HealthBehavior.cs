using GD.My_Game_Project.My_Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GD.My_Game_Project.My_Assets.Scripts.HealthSystem
{
    public class HealthBehavior : MonoBehaviour
    {
        public Health healthData;
        public Slider healthBar;
        private Animator animator;
        private static readonly int Hurt = Animator.StringToHash("GotHit");
        private static readonly int Dead = Animator.StringToHash("Dead");

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

        private void Update()
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
                Die();
            }
        }

        private void Die()
        {
            animator.SetTrigger(Dead);

            if (gameObject.CompareTag("Player"))
            {
                HandlePlayerDeath();
            }
            else if (gameObject.CompareTag("Enemy"))
            {
                HandleEnemyDeath();
            }
        }

        private void HandlePlayerDeath()
        {
            CountdownTimer countdownTimer = FindObjectOfType<CountdownTimer>();
            if (countdownTimer != null)
            {
                countdownTimer.gameOverText.SetActive(true);
            }
            Time.timeScale = 0;
            gameObject.SetActive(false); // Deactivate player
        }

        private void HandleEnemyDeath()
        {
            // Additional logic for enemy death, e.g., dropping loot, updating score, etc.
            gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("Enemy has been defeated.");
        }

        public void Heal(int amount)
        {
            healthData.Heal(amount);
            healthBar.value = healthData.currentHealth;
        }
    }
}
