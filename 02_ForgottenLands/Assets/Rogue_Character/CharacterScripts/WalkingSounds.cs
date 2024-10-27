using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSounds : MonoBehaviour
{
    public AudioSource walkingSound;
    public AudioSource slashingSound;

    // Plays the walking sounds when called by animation event
    public void PlayFootstepSound()
    {
        if (walkingSound != null)
        {
            walkingSound.Play();
        }
    }

    // Plays the slashing sound when called by animation event
    public void PlaySlashingSound()
    {
        if (slashingSound != null)
        {
            slashingSound.Play();
        }
    }
}
