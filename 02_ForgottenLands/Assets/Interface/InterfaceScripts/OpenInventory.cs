using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventoryPanel; // Assign in the Inspector
    public KeyCode toggleKey = KeyCode.Tab; // Key to open/close the inventory

    private bool isInventoryOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isInventoryOpen = !isInventoryOpen;
            inventoryPanel.SetActive(isInventoryOpen);
        }
    }
}
