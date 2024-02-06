using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneShot : MonoBehaviour
{

    public AudioClip[] audioClips;
    public AudioSource audioSource;
   
    public void Play()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }
}
