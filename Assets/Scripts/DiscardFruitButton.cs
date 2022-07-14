using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscardFruitButton : MonoBehaviour
{
    PlayerInventory pInventory;
    Button thisButton;

    public InventoryContainer inventoryContainer;

    // Start is called before the first frame update
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
