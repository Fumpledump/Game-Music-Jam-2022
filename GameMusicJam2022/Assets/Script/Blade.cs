using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Blade : MonoBehaviour
{
    public UnityEvent HitGround;
    public UnityEvent OffGround;
    public GameObject player;
    public bool swordEquipped;
    public float knockForce;

    // Colliders for Blade
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" && swordEquipped)
        {
            // Turn Off Movement
            HitGround.Invoke();
        }

        if (col.gameObject.tag == "Enemy" && swordEquipped)
        {
            StopAllCoroutines();
            Vector2 direction = (col.gameObject.transform.position - player.transform.position).normalized;
            col.rigidbody.AddForce(direction * (knockForce / transform.localScale.x), ForceMode2D.Impulse);

            col.gameObject.GetComponent<EnemyHealth>().TakeDamage();

            StartCoroutine(Reset());
        }

        IEnumerator Reset()
        {
            yield return new WaitForSeconds(.15f);

            if (col.rigidbody != null)
            {
                col.rigidbody.velocity = Vector3.zero;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            // Turn On Movement
            OffGround.Invoke();
        }
    }
}
