using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool dead;
    public SimpleFlash damageEffect;
    public MainMenu mainMenu;
    public Animator animator;
    public PlayerMovement playerMovement;

    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (health <= 0 && !dead)
        {
            dead = true;

            animator.SetBool("Dead", true);
            playerMovement.EnableMovement(false);
            mainMenu.LoadLevel(SceneManager.GetActiveScene().name, 1.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            health--;
            damageEffect.Flash();
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Enemy")
        {
            health--;
            damageEffect.Flash();
        }
    }
}
