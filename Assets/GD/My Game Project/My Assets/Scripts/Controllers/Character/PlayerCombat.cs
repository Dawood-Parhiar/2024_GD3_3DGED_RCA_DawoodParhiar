using System.Collections;
using GD;
using GD.My_Game_Project.My_Assets.Scripts;
using UnityEngine;
public class PlayerCombat : MonoBehaviour
{
    const string ATTACK = "Attack";
    const string GOTHIT = "GotHit";

    [SerializeField] private GameEvent PlayerAttackEvent;
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
        PlayerAttackEvent?.Raise();
        Debug.Log("Player attack event raised.");
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
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyCombat enemyCombat = other.gameObject.GetComponent<EnemyCombat>();
            
            enemyCombat.TakeDamage(20);
        }
    }
}