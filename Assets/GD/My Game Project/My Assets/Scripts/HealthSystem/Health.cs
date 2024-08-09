using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GD.My_Game_Project.My_Assets.Scripts
{
    [CreateAssetMenu(fileName = "Health", menuName = "My Scriptable Objects/Health", order = 1)]
    public class Health : ScriptableObject
    {
        public int maxHealth = 100;
        public int currentHealth = 100;
        public Slider healthBar;
        
        [SerializeField]
        [Header("Descriptive Information (optional)")]
        [ContextMenuItem("Reset Name", "ResetName")]
        private string Name;
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth < 0) currentHealth = 0;
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            if (healthBar != null) healthBar.value = currentHealth;
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
            UpdateHealthBar();
        }
    }
}
