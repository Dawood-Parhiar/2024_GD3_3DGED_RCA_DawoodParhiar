using GD.My_Game_Project.My_Assets.Scripts.HealthSystem;
using UnityEngine;

namespace GD.My_Game_Project.My_Assets.Scripts.Managers
{

    public class EnemyManager : MonoBehaviour
    {
        private EnemyHealthBehavior[] enemies;

        void Start()
        {
            enemies = FindObjectsOfType<EnemyHealthBehavior>();
        }

        public bool AreAllEnemiesKilled()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.healthData.currentHealth > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}