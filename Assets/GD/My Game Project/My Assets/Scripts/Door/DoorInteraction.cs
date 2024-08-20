using GD.My_Game_Project.My_Assets.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace GD.My_Game_Project.My_Assets.Scripts.Door
{
    public class DoorInteraction : MonoBehaviour
    {
        public GameObject doorOpenText;
        public GameObject killEnemiesText;
        private Animator animator;
        private bool isPlayerInRange = false;
        private bool isOpen = false;
        public EnemyManager enemyManager;
   
        void Start()
        {
            animator = GetComponent<Animator>();
            doorOpenText.gameObject.SetActive(false); // Hide the prompt initially
            killEnemiesText.gameObject.SetActive(false); // Hide the prompt initially
        }

        void Update()
        {
        
            if (isPlayerInRange)
            {// if all enemies are killed and player is in range of the door and presses F
                if (enemyManager.AreAllEnemiesKilled())
                {
                    doorOpenText.gameObject.SetActive(true);
                    ToggleDoor();
                }
                else
                {
                    killEnemiesText.gameObject.SetActive(true);
                    doorOpenText.gameObject.SetActive(false); // Hide the prompt
                }
            }
        
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = false;
                doorOpenText.gameObject.SetActive(false); // Hide the prompt
                killEnemiesText.gameObject.SetActive(false); // Hide the prompt
                animator.SetBool("Close",true);
            }
        }

        void ToggleDoor()
        {
            if (!isOpen && Input.GetKeyDown(KeyCode.F))
            {
                isOpen = true;
                animator.SetBool("IsOpen", isOpen);
                doorOpenText.gameObject.SetActive(false); // Hide the prompt after interaction
            }
            else if (isOpen && Input.GetKeyDown(KeyCode.F))
            {
                isOpen = false;
                animator.SetBool("Close", true);
                doorOpenText.gameObject.SetActive(false); // Hide the prompt after interaction
            }
        }
    }
}