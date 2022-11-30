using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChanger : MonoBehaviour
{
    public string track;
    public string sound;
    public bool soundEffect;
    public bool complete;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (complete)
        {
            return;
        }

        if (!soundEffect)
        {
            audioManager.ChangeTrack(track);
        }else
        {
            audioManager.Play(sound);
            complete = true;
        }
    }
}
