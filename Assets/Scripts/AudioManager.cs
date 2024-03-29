﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds = null;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(string soundName)
    {
        Sound sound = Array.Find(sounds, soundClip => soundClip.name == soundName);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found.");
            return;
        }

        if (sound.source == null) { return; }

        if (sound.randomPitch)
        {
            sound.source.pitch = UnityEngine.Random.Range(sound.pitch - 0.2f, sound.pitch + 0.2f);
        }
        else
        {
            sound.source.pitch = sound.pitch;
        }

        sound.source.Play();
    }

    public void Stop(string soundName)
    {
        Sound sound = Array.Find(sounds, soundClip => soundClip.name == soundName);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found.");
            return;
        }

        if (sound.source == null)
        {
            Debug.Log("Sound source not found at this time.");
            return;
        }

        if (sound.source.isPlaying)
        {
            sound.source.Stop();
        }
    }

    public void StopPauseSounds()
    {
        foreach (Sound sound in sounds)
        {
            if (sound.stopOnPause)
            {
                Stop(sound.name);
            }
        }
    }
}
