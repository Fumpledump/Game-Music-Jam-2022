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

    private void Start()
    {
    }

    public void TakeDamage()
    {
        damageEffect.Flash();
        health -= 1;

        //animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            if (!dead)
            {
                Die();

            }
            dead = true;
        }
    }

    private void Die()
    {
        //animator.SetBool("Dead", true);
        Blade.transform.localScale = new Vector3(Blade.transform.localScale.x + swordIncrease, Blade.transform.localScale.y, Blade.transform.localScale.z);
        Destroy(this.gameObject, untilDestroyed);
    }
}
