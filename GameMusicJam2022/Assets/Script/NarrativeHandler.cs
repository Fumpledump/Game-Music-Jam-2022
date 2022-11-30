using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NarrativeHandler : MonoBehaviour
{
    [Header("Set Up")]
    public GameObject player;
    public DialogueRunner dialogSystem; // Yarn Spinner Dialogue Runner

    [Header("Settings")]
    public bool inTrigger; // Can the player start a dialog sequence?
    public bool inDialog; // Is the player in a dialog sequence?
    public NarrativeTrigger currentTrigger;
    public bool interact;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.instance;
    }
    private void Update()
    {
        if (inTrigger && !inDialog)
        {
            if (interact || currentTrigger.automatic)
            {
                if (currentTrigger.greeting != null)
                {
                    audioManager.Play(currentTrigger.greeting);
                }

                inDialog = true;
                dialogSystem.StartDialogue(currentTrigger.node);
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        interact = context.ReadValueAsButton();
    }

    // When Player Completes a Dialogue Sequence
    public void DialogComplete()
    {
        player.GetComponent<PlayerMovement>().controlsOn = true;

        inTrigger = false;
        inDialog = false;

        // Set Trigger to complete so it can not be reactivated
        if(currentTrigger != null)
        {
            if (!currentTrigger.repeatable)
            {
                currentTrigger.triggerComplete = true;
            }
            currentTrigger = null;
        }
    }
}
