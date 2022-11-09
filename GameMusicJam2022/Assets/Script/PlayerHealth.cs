using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(maxHealth);
        health = maxHealth;
        Debug.Log(health);
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            Debug.Log(dead);
        }

        if (health <= 0)
        {
            dead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            health--;
            Debug.Log(health);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            health--;
            Debug.Log(health);
            Destroy(col.gameObject);
        }
    }
}
