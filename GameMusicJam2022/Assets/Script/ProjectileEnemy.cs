using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public GameObject bullet;
    public float projectileSpeed;

    //Player is in range of enemy
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //instantiates projectile
            Bullet shotBullet = Instantiate(bullet, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity).GetComponent<Bullet>();
            shotBullet.projectileSpeed = this.projectileSpeed;
        }
    }
}
