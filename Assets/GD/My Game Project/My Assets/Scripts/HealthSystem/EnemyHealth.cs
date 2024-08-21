using UnityEngine;

namespace GD.My_Game_Project.My_Assets.Scripts.HealthSystem
{
    [CreateAssetMenu(fileName = "Enemy Health", menuName = "My Scriptable Objects/Enemy Health", order = 1)]
    public class EnemyHealth : ScriptableObject
    {
        public int maxHealth = 100;
        public int currentHealth = 100;
       [Header("Character")]
        [SerializeField]private GameObject character;
        public void Initialize()
        {
            currentHealth = maxHealth;
        }
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }

        private void Die()
        {
            if (character)
            {
                character.SetActive(false);
            }
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}