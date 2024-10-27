using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class NPCQuestInteraction : MonoBehaviour
{
    public QuestManager questManager;
    public List<Quest> assignedQuests;                  // List of quests assigned to the NPC
    public GameObject questAcceptCanvas;                // The panel that shows the quest
    public GameObject questInProgressCanvas;            // Shown when the quest is in progress
    public GameObject player;
    public QuestIndicatorController questIndicator;
    public Button acceptButton;                         // Reference to the Accept button
    public float interactionRadius = 1f;
    public float closeDistance = 3f;

    public int currentQuestIndex = 0;                  // Tracks the current quest in the list

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        acceptButton.onClick.AddListener(AcceptQuest);  // Add listener to the Accept button
        UpdateQuestIndicator();
    }
    // Updates every frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // If player is within interaction radius and presses the E key, handle quest interaction
        if (distance <= interactionRadius && Input.GetKeyDown(KeyCode.E))
        {
            HandleQuestInteraction();
        }
        // If the player walks too far away, deactivate both canvases
        else if (distance > closeDistance)
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
        UpdateQuestIndicator();
    }

    // Checks what the current quest status is and what information to return to us
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
        else if (quest.questState == QuestState.Accepted)
        {
            quest.questState = QuestState.Accepted;
            questInProgressCanvas.SetActive(true);  // Show in-progress canvas
        }
        else if (quest.questState == QuestState.Completed)
        {
            questManager.TurnInQuest(quest);  // Complete and turn in the quest

            // Move to the next quest in the list
            currentQuestIndex++;
        }
    }

    // Displays questdetails
    // Calls the Parameter class quest to showcase what information to display
    void DisplayQuestDetails(Quest questToDisplay)
    {
        // Assuming you have text objects in the accept canvas showing quest details
        questAcceptCanvas.transform.Find("QuestName").GetComponent<TMPro.TextMeshProUGUI>().text = questToDisplay.questName;
        questAcceptCanvas.transform.Find("QuestDescription").GetComponent<TMPro.TextMeshProUGUI>().text = questToDisplay.questDescription;
    }

    // Updates the questmanager information that a new quest was accepted and updates the indicators
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

        UpdateQuestIndicator();
    }

    // Showcases the Quest indicators above the NPCs head
    public void UpdateQuestIndicator()
    {
        // Ensure there's a quest to check
        if (currentQuestIndex >= assignedQuests.Count)
        {
            questIndicator.UpdateQuestIndicator(QuestState.TurnedIn);
            return;
        }

        Quest currentQuest = assignedQuests[currentQuestIndex];
        Quest quest = questManager.GetQuestByName(currentQuest.questName);

        if (quest == null || quest.questState == QuestState.NotStarted)
        {
            questIndicator.UpdateQuestIndicator(QuestState.NotStarted);
        }
        else if (quest.questState == QuestState.Accepted)
        {
            questIndicator.UpdateQuestIndicator(QuestState.Accepted);
        }
        else if (quest.questState == QuestState.Completed)
        {
            questIndicator.UpdateQuestIndicator(QuestState.Completed);
        }
    }
}
