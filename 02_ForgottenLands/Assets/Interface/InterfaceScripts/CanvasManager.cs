using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject questLogCanvas;

    private void Start()
    {
        // Ensure the canvas is initially inactive
        questLogCanvas.SetActive(false);
    }

    public void ShowQuestLog()
    {
        questLogCanvas.SetActive(true);
    }

    public void HideQuestLog()
    {
        questLogCanvas.SetActive(false);
    }
}