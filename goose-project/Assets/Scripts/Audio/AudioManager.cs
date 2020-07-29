using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoSingleton<AudioManager>
{
    public Sound[] sounds;

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        Play("NightTheme");
    }

    public void Play(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == clipName);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + clipName + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Play(AudioClip clip)
    {
        Sound s = Array.Find(sounds, sound => sound.clip == clip);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + s.name + " not found!");
            return;
        }
        s.source.PlayOneShot(clip);
    }
}
