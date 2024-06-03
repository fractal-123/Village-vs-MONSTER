using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioSrc => GetComponent<AudioSource>();


    public void PlaySound(AudioClip clip, float volumnMENU = 1f, bool destroyed = false )
    {
        audioSrc.PlayOneShot(clip, volumnMENU);
    }
}
