using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NarrativeHandler : MonoBehaviour
{
    [Header("Set Up")]
    public GameObject player;
    public GameObject dialogPrompt; // UI to tell the player they can start a dialog sequence
    public DialogueRunner dialogSystem; // Yarn Spinner Dialogue Runner

    [Header("Settings")]
    public bool inTrigger; // Can the player start a dialog sequence?
    public bool inDialog; // Is the player in a dialog sequence?
    public NarrativeTrigger currentTrigger;

    private bool dialogInteract;

    private void Update()
    {
        if (inTrigger && !inDialog)
        {
            if (dialogInteract || currentTrigger.automatic)
            {
                inDialog = true;
                dialogSystem.StartDialogue(currentTrigger.node);
            }
        }

        dialogPrompt.SetActive(inTrigger && !inDialog); // If the player can start a dialog sequence and is not already in one show the prompt
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        dialogInteract = context.ReadValueAsButton();
    }

    // When Player Completes a Dialogue Sequence
    public void DialogComplete()
    {
        player.GetComponent<PlayerMovement>().controlsOn = true;

        inTrigger = false;
        inDialog = false;

        // Set Trigger to complete so it can not be reactivated
        if (!currentTrigger.repeatable)
        {
            currentTrigger.triggerComplete = true;
        }
    }
}
