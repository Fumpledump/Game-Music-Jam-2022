using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SwordMovement : MonoBehaviour
{
    public UnityEvent HitGround;
    public UnityEvent OffGround;
    Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Get the Screen positions of the object
        Vector3 objPos = Camera.main.ScreenToWorldPoint(transform.position);

        //Get the Screen position of the mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(-Mouse.current.position.ReadValue());
        mousePos.z = 0;

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(objPos, mousePos);

        direction.z = angle;

        Debug.Log(mousePos);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(direction);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
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
}
