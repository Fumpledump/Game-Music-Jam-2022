using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMushroom : MonoBehaviour
{
    public bool active;
    public float bounce = 20f;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && active)
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

    public void ShroomSwitch()
    {
        active = !active;
    }
}
