using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public CurrencyManager currency;
    public GameObject player;
    public bool chestOpened = false;
    public float interactionRadius = 1f;

    void Start()
    {
        currency = FindObjectOfType <CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance <= interactionRadius)
        {
            openChest();
        }
    }

    void openChest()
    {
        if (!chestOpened)
        {
            chestOpened = true;
            currency.gold += 400;
            currency.UpdateCurrencyUI();
        }
    }
}
