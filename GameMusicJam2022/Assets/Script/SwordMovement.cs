using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SwordMovement : MonoBehaviour
{
    [Header("Set Up")]
    public GameObject player;

    [Header("Settongs")]
    public UnityEvent HitGround;
    public UnityEvent OffGround;
    public bool nearSword;
    public bool swordEquipped;
    public bool controlsOn;

    [Header("Rigidbody Settings")]
    public float swordMass;
    public float swordGravity;
    public float swordDrag;

    private float equipCooldown = 0.5f; // Time before you can equip the sword again.
    private float currentSwordTime;

    private bool equip;
    Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent != null)
        {
            swordEquipped = true;
            player.GetComponent<PlayerMovement>().swordEquipped = true;
        }

        controlsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!controlsOn)
        {
            return;
        }

        // Sword Equipping
        if (currentSwordTime > 0)
        {
            currentSwordTime -= Time.deltaTime;
        }
        else if (equip && nearSword)
        {
            currentSwordTime = equipCooldown;
            EquipSword();
        }


        if (!swordEquipped) // Don't do Sword Movement if the Sword is not equipped
        {
            return;
        }
        else // If Sword is equipped then being near the sword is always true
        {
            nearSword = true;
        }

        //Get the Screen positions of the object
        Vector3 objPos = Camera.main.ScreenToWorldPoint(transform.position);

        //Get the Screen position of the mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(-Mouse.current.position.ReadValue());
        mousePos.z = 0;

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(objPos, mousePos);

        direction.z = angle;

        //Debug.Log(mousePos);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(direction);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    // Colliders for Blade
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" && swordEquipped)
        {
            // Turn Off Movement
            HitGround.Invoke();
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


    // Colliders for Hilt
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            nearSword = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            nearSword = false;
        }
    }

    public void SetEquip(InputAction.CallbackContext context)
    {
        equip = context.ReadValueAsButton();
    }

    private void EquipSword()
    {
        if (swordEquipped) // Unparent Sword and Add Physics
        {
            swordEquipped = false;
            this.gameObject.transform.parent = null;

            // Change Sword to Ground Layer
            this.gameObject.layer = 6;

            // Add RigidBody to Sword
            Rigidbody2D swordRB = this.gameObject.AddComponent<Rigidbody2D>();
            swordRB.mass = swordMass;
            swordRB.gravityScale = swordGravity;
            swordRB.drag = swordDrag;

            player.GetComponent<PlayerMovement>().swordEquipped = false;

            OffGround.Invoke(); // Enable Player Controls Just In Case
        }
        else // Parent Sword to Player and Remove Physics
        {
            swordEquipped = true;

            // Remove Rigidbody from Sword
            Destroy(this.gameObject.GetComponent<Rigidbody2D>());

            // Set Layer to Defaults
            this.gameObject.layer = 0;

            this.gameObject.transform.parent = player.transform; // Parent Sword to Player
            this.gameObject.transform.localPosition = new Vector3(0,0,0); // Reset Sword Position
            player.GetComponent<PlayerMovement>().swordEquipped = true;
        }
    }

    public void EnableControls(bool active)
    {
        controlsOn = active;
    }
}
