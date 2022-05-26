using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip healSound;

    public void PlayHitSound()
    {
        if (audioSource.isActiveAndEnabled)
            audioSource?.PlayOneShot(hitSound);
    }

    public void PlayHealSound()
    {
        if (audioSource.isActiveAndEnabled)
            audioSource?.PlayOneShot(healSound);
    }

    public void PlayDeathSound()
    {
        if (audioSource.isActiveAndEnabled)
            audioSource?.PlayOneShot(deathSound);
    }
}
