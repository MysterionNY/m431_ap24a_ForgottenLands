using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSounds : MonoBehaviour
{
    public AudioSource walkingSound;
    public AudioSource slashingSound;

    // Method to be called by Animation Event
    public void PlayFootstepSound()
    {
        if (walkingSound != null)
        {
            walkingSound.Play();
        }
    }

    public void PlaySlashingSound()
    {
        if (slashingSound != null)
        {
            slashingSound.Play();
        }
    }
}
