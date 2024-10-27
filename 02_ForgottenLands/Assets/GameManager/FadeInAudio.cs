using UnityEngine;
using System.Collections;

public class FadeInAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public float fadeInDuration = 1.0f; // Duration of fade-in effect
    private bool hasFadedIn = false;   // To track if fade-in has already occurred

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.volume = 0;
            audioSource.Play();
            StartCoroutine(FadeIn());
        }
    }

    // Plays the sound when called
    public void PlaySound()
    {
        if (audioSource != null)
        {
            if (!hasFadedIn)
            {
                StartCoroutine(FadeIn());
            }
            else
            {
                audioSource.Play(); // Play sound without fade-in if already faded in
            }
        }
    }

    // Sound slowly fades in
    private IEnumerator FadeIn()
    {
        audioSource.Play();
        float startVolume = 0f;
        float targetVolume = 1f;
        float fadeInDuration = 4.0f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / fadeInDuration);
            audioSource.volume = volume;
            Debug.Log($"Volume: {volume}"); // Debug log for volume
            yield return null;
        }

        audioSource.volume = targetVolume; // Ensure final volume
    }
}
