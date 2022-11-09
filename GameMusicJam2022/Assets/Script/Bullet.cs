using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float projectileSpeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-projectileSpeed * Time.deltaTime, 0, 0);
        Destroy(gameObject,5);
    }
    
}
