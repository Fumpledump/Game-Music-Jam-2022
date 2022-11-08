using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //BulletMovement(projectile);
    }

    //Player is in range of enemy
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //instantiates projectile
            Instantiate(prefab, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
        }
    }

    //public void BulletMovement(GameObject projectile)
    //{
    //    projectile.transform.Translate(-projectileSpeed * Time.deltaTime, 0, 0);
    //}
}
