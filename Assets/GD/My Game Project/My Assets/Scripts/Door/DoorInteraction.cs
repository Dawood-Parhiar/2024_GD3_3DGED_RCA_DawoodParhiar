using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public GameObject doorPromptText; 
    private Animator animator;
    private bool isPlayerInRange = false;
    private bool isOpen = false;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        doorPromptText.gameObject.SetActive(false); // Hide the prompt initially
    }

    void Update()
    {
        // If the player is in range of float 5f and presses F
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            ToggleDoor();
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            doorPromptText.gameObject.SetActive(true); // Show the prompt
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            doorPromptText.gameObject.SetActive(false); // Hide the prompt
        }
    }

    void ToggleDoor()
    {
        isOpen = !isOpen;
        animator.SetBool("IsOpen", isOpen);
        doorPromptText.gameObject.SetActive(false); // Hide the prompt after interaction
        
    }
}