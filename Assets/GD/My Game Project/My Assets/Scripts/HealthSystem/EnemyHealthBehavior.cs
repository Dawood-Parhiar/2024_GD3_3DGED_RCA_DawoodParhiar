using UnityEngine;
using UnityEngine.UI;

namespace GD.My_Game_Project.My_Assets.Scripts.HealthSystem
{
    public class EnemyHealthBehavior : MonoBehaviour
    {
        public EnemyHealth healthData;
        public Slider healthBar;
        private Animator animator;
        private static readonly int Hurt = Animator.StringToHash("GotHit");
        private static readonly int IsDead = Animator.StringToHash("IsDead");

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
                animator.SetTrigger(IsDead);
                Debug.Log("Enemy has health zero.");
                animator.SetBool(IsDead, true);
                gameObject.SetActive(false);
            }
        }
        
        public void Heal(int amount)
        {
            healthData.Heal(amount);
            healthBar.value = healthData.currentHealth;
        }
    }
}
