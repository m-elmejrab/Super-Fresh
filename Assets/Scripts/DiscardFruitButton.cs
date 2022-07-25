using UnityEngine;
using UnityEngine.UI;

public class DiscardFruitButton : MonoBehaviour //UI button for discarding fruits
{
    PlayerInventory playerInventory;
    Button thisButton;

    public InventoryContainer inventoryContainer;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(DiscardButtonClick);
    }

    void DiscardButtonClick()
    {
        playerInventory.ClearInventory(inventoryContainer.GetSelectedFruits());
    }
}
