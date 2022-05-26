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
        audioSource?.PlayOneShot(hitSound);
    }

    public void PlayHealSound()
    {
        audioSource?.PlayOneShot(healSound);
    }

    public void PlayDeathSound()
    {
        audioSource?.PlayOneShot(deathSound);
    }
}
