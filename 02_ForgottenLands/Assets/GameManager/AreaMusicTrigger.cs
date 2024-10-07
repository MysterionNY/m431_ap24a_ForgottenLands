using UnityEngine;

public class AreaMusicTrigger : MonoBehaviour
{
    public AudioClip newMusic; // Assign the new area's music in the inspector
    private AudioManager audioManager;

    private void Start()
    {
        // Find the AudioManager in the scene
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Fade out the current music and fade in the new music
            audioManager.ChangeMusic(newMusic);
        }
    }
}
