using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    static AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void Play(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public static void Play(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
