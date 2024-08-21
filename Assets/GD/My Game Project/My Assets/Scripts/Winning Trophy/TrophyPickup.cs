using System.Collections;
using System.Collections.Generic;
using GD.My_Game_Project.My_Assets.Scripts.Managers;
using UnityEngine;

public class TrophyPickup : MonoBehaviour
{
    [SerializeField] private GameObject winningText;
    [SerializeField] private AudioSource audioSource;
    
    void Start()
    {
        winningText.gameObject.SetActive(false); // Hide the prompt initially
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winningText.gameObject.SetActive(true);
            GameManager.Instance.GameOver();
            audioSource.Play();
        }
    }
}
