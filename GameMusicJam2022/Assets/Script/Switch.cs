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

    public void Update()
    {

        if (nearSwitch && narrativeHandler.interact)
        {
            SwitchActivated.Invoke();
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
