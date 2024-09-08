using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class NPCQuestInteraction : MonoBehaviour
{
    public QuestManager questManager;
    public List<Quest> assignedQuests;  // List of quests assigned to the NPC
    public GameObject questAcceptCanvas;                // The panel that shows the quest
    public GameObject questInProgressCanvas;            // Shown when the quest is in progress
    public GameObject player;
    public Button acceptButton;                         // Reference to the Accept button
    public float interactionRadius = 3f;

    private int currentQuestIndex = 0;                  // Tracks the current quest in the list

    void Start()
    {
        acceptButton.onClick.AddListener(AcceptQuest);  // Add listener to the Accept button
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // If player is within interaction radius and presses the E key, handle quest interaction
        if (distance <= interactionRadius && Input.GetKeyDown(KeyCode.E))
        {
            HandleQuestInteraction();
        }
        // If the player walks too far away, deactivate both canvases
        else if (distance > interactionRadius)
        {
            if (questAcceptCanvas.activeSelf)
            {
                questAcceptCanvas.SetActive(false);  // Close quest accept canvas
            }

            if (questInProgressCanvas.activeSelf)
            {
                questInProgressCanvas.SetActive(false);  // Close quest in-progress canvas
            }
        }
    }

    void HandleQuestInteraction()
    {
        if (currentQuestIndex >= assignedQuests.Count)
        {
            // All quests have been completed or accepted, nothing more to offer
            Debug.Log("All quests have been completed or accepted.");
            return;
        }

        // Get the current quest
        Quest currentQuest = assignedQuests[currentQuestIndex];
        var quest = questManager.GetQuestByName(currentQuest.questName);

        if (quest == null || quest.questState == QuestState.NotStarted)
        {
            questAcceptCanvas.SetActive(true);  // Show quest accept canvas
            DisplayQuestDetails(currentQuest);
        }
        else if (quest.questState == QuestState.Accepted || quest.questState == QuestState.InProgress)
        {
            questInProgressCanvas.SetActive(true);  // Show in-progress canvas
        }
        else if (quest.questState == QuestState.Completed)
        {
            questManager.TurnInQuest(quest);  // Complete and turn in the quest

            // Move to the next quest in the list
            currentQuestIndex++;
        }
    }

    void DisplayQuestDetails(Quest questToDisplay)
    {
        // Assuming you have text objects in the accept canvas showing quest details
        questAcceptCanvas.transform.Find("QuestName").GetComponent<TMPro.TextMeshProUGUI>().text = questToDisplay.questName;
        questAcceptCanvas.transform.Find("QuestDescription").GetComponent<TMPro.TextMeshProUGUI>().text = questToDisplay.questDescription;
    }

    public void AcceptQuest()
    {
        if (currentQuestIndex >= assignedQuests.Count)
        {
            Debug.Log("No more quests to accept.");
            return;
        }

        Quest currentQuest = assignedQuests[currentQuestIndex];

        Quest newQuest = new Quest
        {
            questName = currentQuest.questName,
            questDescription = currentQuest.questDescription,
            steps = currentQuest.steps,
            rewardGold = currentQuest.rewardGold,
            questState = QuestState.Accepted
        };

        questManager.AcceptQuest(newQuest);
        questAcceptCanvas.SetActive(false);  // Hide quest accept canvas after accepting
    }
}
