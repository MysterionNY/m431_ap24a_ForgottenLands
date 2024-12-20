using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    public GameObject questLogPanel;  // This is the panel that will be shown/hidden
    public GameObject questButtonPrefab;
    public Transform questListParent;

    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI questDescriptionText;
    public TextMeshProUGUI questStepsText;
    public TextMeshProUGUI questRewardText;

    private QuestManager questManager;
    private bool isQuestLogOpen = false;  // Tracks whether the quest log is open or not

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        questLogPanel.SetActive(false);  // Ensure the quest log is closed at start
    }

    // Updates on every frame
    void Update()
    {
        // Check for the Tab key press to toggle the quest log
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleQuestLog();
        }
    }

    // Function to toggle the quest log
    public void ToggleQuestLog()
    {
        isQuestLogOpen = !isQuestLogOpen;
        questLogPanel.SetActive(isQuestLogOpen);

        // If opening the quest log, update the UI
        if (isQuestLogOpen)
        {
            UpdateQuestLogUI();
            ClearQuestDetails();
        }
    }

    // Update the quest log ui to show the active quests
    public void UpdateQuestLogUI()
    {
        if (questListParent == null)
        {
            Debug.LogError("QuestListParent is not assigned.");
            return;
        }

        if (questButtonPrefab == null)
        {
            Debug.LogError("QuestButtonPrefab is not assigned.");
            return;
        }

        if (questManager == null)
        {
            Debug.LogError("QuestManager is not assigned.");
            return;
        }
        // Clear existing buttons
        foreach (Transform child in questListParent)
        {
            Destroy(child.gameObject);
        }

        // Add quest buttons
        foreach (Quest quest in questManager.activeQuests)
        {
            GameObject button = Instantiate(questButtonPrefab, questListParent);
            button.GetComponentInChildren<TextMeshProUGUI>().text = quest.questName;  // Update to TextMeshProUGUI
            button.GetComponent<Button>().onClick.AddListener(() => ShowQuestDetails(quest));
        }
    }

    // Show the quest details when opened
    // Parameter calls the Quest class to check for the current quest step details
    public void ShowQuestDetails(Quest quest)
    {
        questNameText.text = quest.questName;
        questDescriptionText.text = quest.questDescription;

        // Show steps
        questStepsText.text = "";
        foreach (var step in quest.steps)
        {
            questStepsText.text += step.stepDescription + " - " + step.currentCount + "/" + step.targetCount + "\n";
        }

        // Show rewards
        questRewardText.text = "Gold Reward: " + quest.rewardGold.ToString();
    }

    // When this function is called, it will remove all the quest information
    public void ClearQuestDetails()
    {
        questNameText.text = "";
        questDescriptionText.text = "";
        questStepsText.text = "";
        questRewardText.text = "";
    }
}
