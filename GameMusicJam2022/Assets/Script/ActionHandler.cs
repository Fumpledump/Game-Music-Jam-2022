using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    public NarrativeHandler narrativeHandler;
    public Switch currentSwitch;
    public GameObject InteractionPrompt;


    public void Update()
    {
        if (currentSwitch != null)
        {
            InteractionPrompt.SetActive(true);
        }else if (narrativeHandler.currentTrigger != null && !narrativeHandler.inDialog)
        {
            InteractionPrompt.SetActive(true);
        }
        else
        {
            InteractionPrompt.SetActive(false);
        }
    }
}
