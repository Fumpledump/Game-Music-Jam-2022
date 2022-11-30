using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{
    public NarrativeHandler narrativeHandler;

    public string node;
    public bool automatic;
    public bool repeatable;
    public bool triggerComplete;
    public string greeting;

    // Checks if the Player is inside the Narrative Trigger
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !triggerComplete)
        {
            narrativeHandler.inTrigger = true;
            narrativeHandler.currentTrigger = this;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && !triggerComplete)
        {
            narrativeHandler.inTrigger = false;
            narrativeHandler.currentTrigger = null;
        }
    }
}
