using UnityEngine;
using UnityEngine.AI;

namespace GD.My_Game_Project.My_Assets.Scripts.Controllers.Character
{
    public class PlayerMovement : MonoBehaviour
    {
        // this script is sourced from https://www.youtube.com/watch?v=LVu3_IVCzys
        // and is used to control the player character using the NavMeshAgent component
        // and the PlayerInput component
    
    
        const string IDLE = "Idle";
        const string RUN = "Run";
        const string JUMP = "Jump";
        const string ATTACK = "Attack";
    
        PlayerInput input;
        NavMeshAgent agent;
        Animator animator;
        PlayerCombat playerCombat;// Script
    
        [Header("Movement")]
        [SerializeField] ParticleSystem clickEffect;
        [SerializeField] LayerMask clickableLayers;

        float lookRotationSpeed = 8f;
        GameObject target;
    
        void Awake() 
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            input = new PlayerInput();
            playerCombat = GetComponent<PlayerCombat>();
            AssignInputs();
            LootBox box = FindObjectOfType<LootBox>();
            if (box) box.OnBoxOpen += GetChestItems;
        }

        private void GetChestItems(GameObject[] obj)
        {
            foreach (GameObject item in obj)
            {
                Debug.Log("Player got " + item.name);
            }
        }


        void AssignInputs()
        {
            input.Main.Move.performed += ctx => ClickToMove();
            input.Main.Attack.performed += ctx => playerCombat.Attack();
        }
        void ClickToMove()
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers)) 
            {
                target = null;
                agent.destination = hit.point;
                if(clickEffect != null)
                { Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
            }
        }
        void OnEnable() 
        { input.Enable(); }
        void OnDisable() 
        { input.Disable();}
        void Update() 
        { FaceTarget(); SetAnimations(); }
        void FaceTarget()
        {
            if(agent.destination == transform.position) return;
            Vector3 facing = Vector3.zero;
            if(target != null)
            { facing = target.transform.position; }
            else
            { facing = agent.destination; }
        
            Vector3 direction = (agent.destination - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed); 
        }

        private bool IsGrounded()
        { return Physics.Raycast(transform.position, Vector3.down, 0.2f); }
        void SetAnimations()
        {
            if(!playerCombat.playerBusy)   
            {
                if(!IsGrounded())
                { animator.Play(JUMP); }
                else if (agent.velocity == Vector3.zero)
                { animator.Play(IDLE); }
                else
                { animator.Play(RUN); }
            }
        }
    }
}

