using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{

    public GameObject prefab;
    public float projectileSpeed;
    private GameObject projectile;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(projectileSpeed);
        projectile = Instantiate(prefab, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        projectile.transform.Translate(-projectileSpeed * Time.deltaTime, 0, 0);
    }
}
