using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonFlash : MonoBehaviour
{
    public Button button;
    public float flashDuration = 0.2f; // Duration of the flash
    private Color originalColor;
    private Image buttonImage;

    void Start()
    {
        if (button == null)
        {
            button = GetComponent<Button>();
        }

        buttonImage = button.GetComponent<Image>();
        originalColor = buttonImage.color;

        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        StartCoroutine(FlashButton());
    }

    IEnumerator FlashButton()
    {
        // Create a flash color with reduced opacity
        Color flashColor = originalColor;
        flashColor.a = 0.3f; // Set opacity to 0.3

        // Change color to flashColor
        buttonImage.color = flashColor;

        yield return new WaitForSeconds(flashDuration);

        // Change color back to original
        buttonImage.color = originalColor;
    }
}
