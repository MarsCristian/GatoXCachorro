using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayOneShot : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public void Play()
    {
        audioSource.Stop();
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }
}
