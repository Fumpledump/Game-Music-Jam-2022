using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public SimpleFlash damageEffect;
    public float health;
    public float maxHealth;
    public bool dead;
    public float untilDestroyed;

    [Header("Sword Settings")]
    public GameObject Blade;
    public float swordIncrease;

    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.instance;

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void TakeDamage()
    {
        audioManager.Play("EnemyDamaged");
        damageEffect.Flash();
        health -= 1;

        //animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            if (!dead)
            {
                audioManager.Play("EnemyDie");
                animator.SetTrigger("Dead");
                Die();
            }
            dead = true;
        }
    }

    private void Die()
    {
        //animator.SetBool("Dead", true);
        audioManager.Play("SwordGrow");
        Blade.transform.localScale = new Vector3(Blade.transform.localScale.x + swordIncrease, Blade.transform.localScale.y, Blade.transform.localScale.z);
        Destroy(this.gameObject, untilDestroyed);
    }
}
