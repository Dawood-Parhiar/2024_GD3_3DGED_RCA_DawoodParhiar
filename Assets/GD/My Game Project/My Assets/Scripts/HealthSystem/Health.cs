using UnityEngine;

namespace GD.My_Game_Project.My_Assets.Scripts
{
    [CreateAssetMenu(fileName = "Health", menuName = "My Scriptable Objects/Player Health", order = 1)]
    public class Health : ScriptableObject
    {
        public int maxHealth = 100;
        public int currentHealth = 100;

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