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

    [Header("Settings")]
    public bool controlsOn;
    public float speed = 8f; // Movement Speed of the Player
    public float jumpForce = 10f; // How far the player can jump
    public float glideSpeed;
    public Vector2 moveDirection = Vector2.zero;

    private bool jump;
    private bool facingRight = true; // Direction of the sprite
    private float intialGravityScale;

    private void Start()
    {
        controlsOn = true;
        intialGravityScale = rb.gravityScale;
    }

    private void Update()
    {
        // Jumping
        if (jump && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Gliding
        if (jump && rb.velocity.y <= 0)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, -glideSpeed);
        }
        else
        {
            rb.gravityScale = intialGravityScale;
        }

        //Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);
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
        if (controlsOn)
        {
            jump = context.ReadValueAsButton();
        }
    }

    private void Flip()
    {
        if (facingRight && moveDirection.x < 0 || !facingRight && moveDirection.x > 0)
        {
            facingRight = !facingRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
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
