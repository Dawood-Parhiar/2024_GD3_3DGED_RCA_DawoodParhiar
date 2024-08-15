using System.Collections;
using GD;
using GD.My_Game_Project.My_Assets.Scripts.HealthSystem;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;
    public bool isAttacking = false;
    private EnemyHealthBehavior enemyHealth;
    [SerializeField] private float damageAfterTime;
    [SerializeField] private float strongDamageAfterTime;
    [SerializeField] private int damage;
    [SerializeField] private AttackArea attackArea;
    [SerializeField] private GameEvent playerAttackEvent;
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    void Awake()
    {
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealthBehavior>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        if (isAttacking) return;
        animator.SetTrigger("SimpleAttack");
        StartCoroutine(nameof(Hit), false);
    }

    public void StrongAttack()
    {
        if (isAttacking) return;
        animator.SetTrigger("StrongAttack");
        PlayAttackSound();
        StartCoroutine(nameof(Hit), true);
    }

    private IEnumerator Hit(bool strong)
    {
        isAttacking = true;
        playerAttackEvent?.Raise();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        
        foreach (var attackAreaDamageable in attackArea.damagablesInRange)
        {
            attackAreaDamageable.Damage(damage * (strong ? 3 : 1));
            
        }
        yield return new WaitForSeconds(strong ? strongDamageAfterTime : damageAfterTime);
        isAttacking = false;
    }

    private void PlayAttackSound()
    {
        if (audioSource)
        {
            audioSource.Play();
        }
    }
}
