using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hilt : MonoBehaviour
{
    [Header("Set Up")]
    public GameObject player;
    public GameObject pivot;
    public Blade blade;
    public Animator animator;
    public Animator playerAnimator;

    [Header("Settongs")]
    public bool nearSword;
    public bool swordEquipped;
    public bool controlsOn;
    public Vector3 swordOffset;

    [Header("Rigidbody Settings")]
    public float swordMass;
    public float swordGravity;
    public float swordDrag;

    private float equipCooldown = 0.5f; // Time before you can equip the sword again.
    private float currentSwordTime;

    private bool equip;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;

        if (pivot.transform.parent != null)
        {
            swordEquipped = true;
            player.GetComponent<PlayerMovement>().swordEquipped = true;
        }

        if (playerAnimator == null)
        {
            playerAnimator = player.GetComponent<Animator>();
        }

        if (animator == null)
        {
            animator = this.GetComponent<Animator>();
        }

        controlsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            blade.swordEquipped = false;
            animator.SetBool("SwordEquipped", false);
            playerAnimator.SetBool("SwordEquipped", false);
            pivot.gameObject.transform.parent = null;

            // Change Blade to Ground Layer
            blade.gameObject.layer = 6;

            // Add RigidBody to Sword
            Rigidbody2D swordRB = pivot.gameObject.AddComponent<Rigidbody2D>();
            swordRB.mass = swordMass;
            swordRB.gravityScale = swordGravity;
            swordRB.drag = swordDrag;

            player.GetComponent<PlayerMovement>().swordEquipped = false;
            blade.GetComponent<Blade>().OffGround.Invoke(); // Enable Player Controls
            EnableControls(false);
        }
        else // Parent Sword to Player and Remove Physics
        {
            audioManager.Play("SwordGet");
            swordEquipped = true;
            blade.swordEquipped = true;
            animator.SetBool("SwordEquipped", true);
            playerAnimator.SetBool("SwordEquipped", true);


            // Remove Rigidbody from Sword
            Destroy(pivot.gameObject.GetComponent<Rigidbody2D>());

            // Set Layer to Defaults
            blade.gameObject.layer = 0;

            pivot.gameObject.transform.parent = player.transform; // Parent Sword to Player
            pivot.gameObject.transform.localPosition = swordOffset; // Reset Sword Position

            player.GetComponent<PlayerMovement>().swordEquipped = true;
            EnableControls(true);
        }
    }

    public void EnableControls(bool active)
    {
        controlsOn = active;
    }
}
