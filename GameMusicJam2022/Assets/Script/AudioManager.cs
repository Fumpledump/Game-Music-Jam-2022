using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup mainMixer;
    public Sound[] music;
    public Sound[] sounds;
    public static AudioManager instance;
    public Sound curTrack;
    public string startTrack;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = mainMixer;
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound m in music)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.outputAudioMixerGroup = mainMixer;
            m.source.clip = m.clip;
            
            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;
        }
    }

    public void Start()
    {
        curTrack = Array.Find(music, sound => sound.name == startTrack);
        if (curTrack == null)
        {
            Debug.LogWarning("Music: " + name + " not found");
            return;
        }
        curTrack.source.Play();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void ChangeTrack(string name)
    {
        if (curTrack.name == name)
        {
            return;
        }

        curTrack.source.Stop();
        curTrack = null;

        curTrack = Array.Find(music, sound => sound.name == name);
        if (curTrack == null)
        {
            Debug.LogWarning("Music: " + name + " not found");
            return;
        }
        curTrack.source.Play();
    }
}
