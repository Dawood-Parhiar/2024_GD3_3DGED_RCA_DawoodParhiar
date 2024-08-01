// EnemyCombat.cs
using System;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    const string GotHit = "GotHit";

    [Header("Health")]
    [SerializeField] private Health enemyHealth;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        enemyHealth.TakeDamage(damage);
        animator.SetBool(GotHit, true);
        if (enemyHealth.currentHealth <= 0)
        {
            // Handle enemy death
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with player.");
            PlayerCombat playerCombat = other.gameObject.GetComponent<PlayerCombat>();
            playerCombat.TakeDamage(10);
        }
    }
}