using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool dead;
    public SimpleFlash damageEffect;

    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(maxHealth);
        health = maxHealth;
        //Debug.Log(health);
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

        if(dead == true)
        {
            Debug.Log(dead);

            health = maxHealth;
            dead = false;
        }

        if (health <= 0)
        {
            dead = true;
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
        if (col.gameObject.tag == "Shooter")
        {
            health--;
            damageEffect.Flash();
            Destroy(col.gameObject);
        }
    }
}
