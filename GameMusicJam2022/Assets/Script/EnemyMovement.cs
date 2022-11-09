using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float range = 3f;
    public float speed = 1f;

    float startingX;
    int direction = 1;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * direction);
        if ((transform.position.x <= startingX && !facingRight) || (transform.position.x >= startingX + range && facingRight))
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            direction *= -1;
        }
    }
}
