using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscardFruitButton : MonoBehaviour //UI button for discarding fruits
{
    PlayerInventory pInventory;
    Button thisButton;

    public InventoryContainer inventoryContainer;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pInventory = player.GetComponent<PlayerInventory>();

        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(DiscardButtonClick);

    }

    void DiscardButtonClick()
    {
        pInventory.ClearInventory(inventoryContainer.GetSelectedFruits());
    }
}
