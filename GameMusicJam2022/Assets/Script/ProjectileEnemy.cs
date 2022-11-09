using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        time = Time.time;
    }

    private void Update()
    {
        second = (int)time;
    }

    //Player is in range of enemy

    //Player enters trigger
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //instantiates projectile
            Bullet shotBullet = Instantiate(bullet, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity).GetComponent<Bullet>();
            shotBullet.projectileSpeed = this.projectileSpeed;            
        }

    }

    //While Player is in trigger
    private void OnTriggerStay2D(Collider2D col)
    {
        time += Time.deltaTime;
        second = (int)time;
        if (second / fireRate == 1)
        {
            //instantiates bullet
            Bullet shotBullet = Instantiate(bullet, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity).GetComponent<Bullet>();
            shotBullet.projectileSpeed = this.projectileSpeed;
            //resets time
            time = 0;
            second = 0;
             
        }
    }

    //When Player Exits Trigger
    private void OnTriggerExit2D(Collider2D col)
    {
        //Resets time
        time = 0;
        second = 0;
    }
}
