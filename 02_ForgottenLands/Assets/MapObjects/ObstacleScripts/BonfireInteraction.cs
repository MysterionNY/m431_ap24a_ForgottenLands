using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonfireInteraction : MonoBehaviour
{
    public GameObject player;
    public float interactionRadius = 1f;
    public TextMeshProUGUI gameSavedText;
    public float textMoveDistance = 50f;
    public float fadeDuration = 2f;

    void Start()
    {
        gameSavedText.gameObject.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance <= interactionRadius)
        {
            activateBonfire();
        }
    }

    void activateBonfire()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.SaveGameData();
            StartCoroutine(ShowGameSavedText());
        }
        else
        {
            Debug.LogError("GameManager not found!");
        }
    }

    IEnumerator ShowGameSavedText()
    {
        // Make the text visible
        gameSavedText.gameObject.SetActive(true);

        // Store the original position and color of the text
        Vector3 originalPosition = gameSavedText.rectTransform.anchoredPosition;
        Color originalColor = gameSavedText.color;

        // Set the start time for the animation
        float startTime = Time.time;

        while (Time.time < startTime + fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;

            // Move the text upwards over time
            gameSavedText.rectTransform.anchoredPosition = originalPosition + Vector3.up * textMoveDistance * t;

            // Gradually fade out the text
            gameSavedText.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, t));

            yield return null;
        }

        // Reset the text position and color
        gameSavedText.rectTransform.anchoredPosition = originalPosition;
        gameSavedText.color = originalColor;

        // Hide the text after the fade-out is complete
        gameSavedText.gameObject.SetActive(false);
    }
}
