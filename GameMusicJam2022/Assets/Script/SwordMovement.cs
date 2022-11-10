using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordMovement : MonoBehaviour
{
    [Header("Set Up")]
    public GameObject player;
    public Blade blade;
    public Hilt hilt;
    public Animator animator;
    public Animator playerAnimator;

    [Header("Rigidbody Settings")]
    public float swordMass;
    public float swordGravity;
    public float swordDrag;
    Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if (playerAnimator == null)
        {
            playerAnimator = player.GetComponent<Animator>();
        }

        if (animator == null)
        {
            animator = this.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hilt.controlsOn)
        {
            return;
        }

        // Get the World positions of the object
        Vector3 objPos = transform.position;

        // Get the World position of the mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(objPos, mousePos);

        direction.z = angle;

        transform.rotation = Quaternion.Euler(0, 0, direction.z + 180);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
