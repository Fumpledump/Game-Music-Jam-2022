using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Set Up")]
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject Blade;
    public Animator animator;

    [Header("Movement Settings")]
    public bool controlsOn;
    public float speed = 8f; // Movement Speed of the Player
    public float jumpForce = 10f; // How far the player can jump
    public float glideSpeed;

    [Header("Sword Settings")]
    public bool swordEquipped;
    public float swordSize;
    [Range (0,3)]
    public float swordMoveScale;
    [Range(0, 3)]
    public float swordJumpScale;
    [Range(0, 3)]
    public float swordGlideScale;

    private bool jump;
    private bool equip;
    private bool facingRight = true; // Direction of the sprite
    private float intialGravityScale;
    private Vector2 moveDirection = Vector2.zero;

    private void Start()
    {
        controlsOn = true;
        intialGravityScale = rb.gravityScale;

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {


        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x)); 

        if (swordEquipped)
        {
            swordSize = Blade.transform.localScale.x;
        }

        // Jumping
        if (controlsOn && jump && isGrounded())
        {
            animator.SetBool("Jump", true);

            if (swordEquipped)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce - (swordSize * swordJumpScale));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }else if (isGrounded())
        {
            animator.SetBool("Jump", false);
        }

        // Gliding
        if (controlsOn && jump && rb.velocity.y <= 0)
        {
            animator.SetBool("Glide", true);
            rb.gravityScale = 0;

            // If Sword Equipped then Increease Slide Speed Down
            if (swordEquipped)
            {
                rb.velocity = new Vector2(rb.velocity.x, -glideSpeed - (swordSize * swordGlideScale));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -glideSpeed);
            }
        }
        else
        {
            animator.SetBool("Glide", false);
            rb.gravityScale = intialGravityScale;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        // Decrease Speed if Sword is Equipped
        if (swordEquipped)
        {
            rb.velocity = new Vector2(moveDirection.x * (speed - (swordSize * swordMoveScale)), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);
        }

    }

    public void SetMovement(InputAction.CallbackContext context)
    {
        if (controlsOn)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    public void SetJump(InputAction.CallbackContext context)
    {
        jump = context.ReadValueAsButton();
    }

    private void Flip()
    {
        if (facingRight && moveDirection.x < 0 || !facingRight && moveDirection.x > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = facingRight;
            facingRight = !facingRight;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    public void EnableMovement(bool turnOn)
    {
        if (turnOn)
        {
            controlsOn = true;
        }
        else
        {
            controlsOn = false;
            moveDirection = Vector2.zero;
        }
    }
}
