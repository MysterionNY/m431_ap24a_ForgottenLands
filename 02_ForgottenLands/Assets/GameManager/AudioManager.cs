using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioSource tempSource; // A temporary AudioSource for crossfading
    public float fadeDuration = 4f; // Duration for the fade effect
    public float targetVolume = 0.15f;
    void Start()
    {
        // Initialize the temporary AudioSource for fading
        tempSource = gameObject.AddComponent<AudioSource>();
        tempSource.loop = true; // Ensure looping for area music
    }

    public void ChangeMusic(AudioClip newClip)
    {
        if (tempSource.isPlaying)
        {
            StartCoroutine(FadeOutAndChangeMusic(newClip));
        }
        else
        {
            StartCoroutine(FadeInNewMusic(newClip));
        }
    }

    private IEnumerator FadeOutAndChangeMusic(AudioClip newClip)
    {
        float currentTime = 0;
        float startVolume = audioSource.volume;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / fadeDuration);
            yield return null;
        }

        audioSource.Stop(); // Stop the current music

        // Switch to the new music
        tempSource.clip = newClip;
        tempSource.Play();

        // Fade in the new music
        currentTime = 0;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            tempSource.volume = Mathf.Lerp(0, targetVolume, currentTime / fadeDuration);
            yield return null;
        }

        // Swap the sources
        audioSource.clip = newClip; // Set the main source clip
        audioSource.Play(); // Play the new music
        audioSource.volume = targetVolume;
        Destroy(tempSource); // Destroy the temporary source
    }

    private IEnumerator FadeInNewMusic(AudioClip newClip)
    {
        audioSource.clip = newClip;
        audioSource.Play();
        audioSource.volume = 0;
        audioSource.loop = true;

        float currentTime = 0;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, targetVolume, currentTime / fadeDuration);
            yield return null;
        }
    }
}
