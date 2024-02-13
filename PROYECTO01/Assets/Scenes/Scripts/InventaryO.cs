using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory2D : MonoBehaviour
{
    public bool InventoryEnabled { get; set; }

    public GameObject inventoryUI;
    private int allSlots;
    private GameObject[] slots;
    public GameObject slotHolder;

    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slots = new GameObject[allSlots];

        // Initialize slots
        for (int i = 0; i < allSlots; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

            // Aquí no se necesitan cambios en los slots
        }
    }

    void Update()
    {
        // Toggle inventory visibility
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InventoryEnabled = !InventoryEnabled;
            inventoryUI.SetActive(InventoryEnabled);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Item"))
        {
            GameObject itemCollected = other.gameObject;
            Item item = itemCollected.GetComponent<Item>();
            if (item != null)
            {
                AddItem(itemCollected, item.itemID, item.Type, item.Description, item.Icon);
            }
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            Slot slotComponent = slots[i].GetComponent<Slot>();
            if (slotComponent != null && slotComponent.empty)
            {
                slotComponent.item = itemObject;
                slotComponent.ID = itemID;
                slotComponent.type = itemType;
                slotComponent.description = itemDescription;
                slotComponent.icon = itemIcon;

                itemObject.transform.parent = slots[i].transform;
                itemObject.SetActive(false);

                slotComponent.UpdateSlot();

                slotComponent.empty = false;

                return; // Exit the method after adding the item
            }
        }
    }
}
