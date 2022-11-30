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
    public float swordSurfTime;

    private AudioManager audioManager;
    private Coroutine swordSurfTimer;

    private void Start()
    {
        audioManager = AudioManager.instance;
    }

    // Colliders for Blade
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" && swordEquipped)
        {
            audioManager.Play("BladeHit");

            if (swordSurfTimer != null)
            {
                StopCoroutine(swordSurfTimer);
            }

            swordSurfTimer = StartCoroutine(SwordSurfRoutine(swordSurfTime));
        }

        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Shooter" && swordEquipped)
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
            if (swordSurfTimer != null)
            {
                StopCoroutine(swordSurfTimer);
            }
        }
    }

    IEnumerator SwordSurfRoutine(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        // Turn Off Movement
        HitGround.Invoke();
    }
}
