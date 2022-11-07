using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public NarrativeHandler narrativeHandler;
    public ActionHandler actionHandler;
    public bool nearSwitch;

    public UnityEvent SwitchActivated;

    private float switchCooldown = 0.5f; // Time before switch can be used again.
    private float currentSwitchTime;

    private void Start()
    {
    }

    private void Update()
    {
        if (currentSwitchTime > 0)
        {
            currentSwitchTime -= Time.deltaTime;
        }else if (nearSwitch && narrativeHandler.interact)
        {
            SwitchActivated.Invoke();
            currentSwitchTime = switchCooldown;
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            nearSwitch = true;
            actionHandler.currentSwitch = this;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            nearSwitch = false;
            actionHandler.currentSwitch = null;
        }
    }
}
