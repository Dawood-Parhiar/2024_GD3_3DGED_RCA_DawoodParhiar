using UnityEngine;

namespace GD.My_Game_Project.My_Assets.Scripts
{
    [CreateAssetMenu(fileName = "Health", menuName = "My Scriptable Objects/Health", order = 1)]
    public class Health : ScriptableObject
    {
        const int MaxHealth = 100;
        public int currentHealth = 100;
        
        [SerializeField]
        [Header("Descriptive Information (optional)")]
        [ContextMenuItem("Reset Name", "ResetName")]
        private string Name;
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth < 0) currentHealth = 0;
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
            if (currentHealth > MaxHealth) currentHealth = MaxHealth;
        }
    }
}
