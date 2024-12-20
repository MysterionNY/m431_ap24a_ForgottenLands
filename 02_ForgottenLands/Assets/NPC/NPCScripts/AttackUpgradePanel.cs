using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class AttackUpgradePanel : MonoBehaviour
{
    public GameObject upgradePanel;           // Panel that displays upgrade info
    public TextMeshProUGUI currentLevelText;  // Displays the current attack level
    public TextMeshProUGUI currentDamageText; // Displays current attack damage
    public TextMeshProUGUI nextDamageText;    // Displays next level's attack damage
    public TextMeshProUGUI upgradeCostText;   // Displays the cost for the next upgrade
    public float interactionRadius = 2f;      // Radius within which the panel can be interacted with
    public float closeDistance = 5f;          // Distance at which the panel should automatically close

    private RogueAttack rogueAttack;
    private GameObject player;
    private bool isPanelOpen = false;

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        rogueAttack = FindObjectOfType<RogueAttack>(); // Find the RogueAttack script in the scene
        if (rogueAttack == null)
        {
            Debug.LogError("RogueAttack script not found!");
        }
        player = GameObject.FindWithTag("Player");
        upgradePanel.SetActive(false); // Hide panel at start
    }

    // Updates on every frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distance <= interactionRadius)
            {
                TogglePanel();
            }
        }

        if (isPanelOpen)
        {
            if (distance > closeDistance)
            {
                ClosePanel();
            }
        }
    }

    // Calls the deactivate or activate panel
    void TogglePanel()
    {
        if (upgradePanel.activeSelf)
        {
            ClosePanel();
        }
        else
        {
            OpenPanel();
        }
    }

    // Opens the panel to showcase the upgrades
    public void OpenPanel()
    {
        if (rogueAttack != null)
        {
            // Update the panel with the player's current stats and upgrade info
            currentLevelText.text = "+" + rogueAttack.currentAttackLevel.ToString() + " Damage";
            currentDamageText.text = "" + rogueAttack.attackDamage.ToString();
            upgradeCostText.text = "Cost: " + rogueAttack.upgradeCost.ToString("0");
            if(rogueAttack.currentAttackLevel == 10){
                nextDamageText.text = "" + rogueAttack.attackDamage.ToString();
            } else{
                nextDamageText.text = "" + (rogueAttack.attackDamage + rogueAttack.damageIncrease).ToString();
            }

            upgradePanel.SetActive(true); // Show the panel
            isPanelOpen = true;
        }
    }

    // Closes the panel
    public void ClosePanel()
    {
        upgradePanel.SetActive(false); // Hide the panel
        isPanelOpen = false;
    }

    // calls for the function to upgrade attack from the player attack class
    public void UpgradeAttack()
    {
        if (rogueAttack != null && rogueAttack.UpgradeAttack())
        {
            // Successfully upgraded, refresh the panel to show new stats
            OpenPanel();
        }
    }
}
