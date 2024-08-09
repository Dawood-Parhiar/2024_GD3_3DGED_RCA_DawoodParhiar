using System.Collections;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCombat : MonoBehaviour
{
    const string ATTACK = "Attack";
    const string GOTHIT = "GotHit";

    [FormerlySerializedAs("PlayerAttackEvent")] [SerializeField] private GameEvent playerAttackEvent;
    [SerializeField] private Health playerHealth;

    Animator animator;
    bool playerBusy = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Attack()
    {
        if (!playerBusy)
        {
            playerBusy = true;
            animator.SetBool(ATTACK, true);
            StartCoroutine(PerformAttack());
        }
    }
    private IEnumerator PerformAttack()
    {
        playerAttackEvent?.Raise();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool(ATTACK, false);
        playerBusy = false;
    }
    public void TakeDamage(int damage)
    {
        playerHealth.TakeDamage(damage);
        animator.SetBool(GOTHIT, true);
        if (playerHealth.currentHealth <= 0)
        {
            // Handle player death
            Destroy(gameObject);
        }
    }
}