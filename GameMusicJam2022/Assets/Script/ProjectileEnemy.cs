using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public GameObject bullet;
    public float projectileSpeed;
    private float time;
    private int second;
    public int fireRate;
    [Range (-1, 1)]
    public int direction;

    private void Start()
    {
        //time = Time.time;
    }

    private void Update()
    {
        time += Time.deltaTime;
        second = (int)time;
        Debug.Log(second);
    }

    //Player is in range of enemy

    //Player enters trigger
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //instantiates projectile
            Bullet shotBullet = Instantiate(bullet, new Vector2(transform.position.x + direction, transform.position.y), Quaternion.identity).GetComponent<Bullet>();
            shotBullet.projectileSpeed = this.projectileSpeed;
            shotBullet.direction = this.direction;
            time = 0;
            second = 0;
        }

    }

    //While Player is in trigger
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //time += Time.deltaTime;
            if (second / fireRate == 1)
            {
                //instantiates bullet
                Bullet shotBullet = Instantiate(bullet, new Vector2(transform.position.x + direction, transform.position.y), Quaternion.identity).GetComponent<Bullet>();
                shotBullet.direction = this.direction;
                shotBullet.projectileSpeed = this.projectileSpeed;
                //resets time
                time = 0;
                second = 0;

            }
        }
            
    }

    //When Player Exits Trigger
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Resets time
            time = 0;
            second = 0;
        }
            
    }
}
