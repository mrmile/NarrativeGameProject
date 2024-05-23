using UnityEngine;
using UnityEngine.UI; // Make sure to include this namespace
using TMPro; // Include this namespace for TextMeshPro
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public UnityEngine.UI.Image[] itemSlots; // Explicitly specify UnityEngine.UI.Image
    public GameObject itemDescriptionPanel;
    public TextMeshProUGUI itemNameText; // Use TextMeshProUGUI for TextMeshPro
    public TextMeshProUGUI itemDescriptionText; // Use TextMeshProUGUI for TextMeshPro

    private Dictionary<UnityEngine.UI.Image, Inventory.Item> itemSlotDictionary = new Dictionary<UnityEngine.UI.Image, Inventory.Item>();

    private void Start()
    {
        foreach (UnityEngine.UI.Image slot in itemSlots)
        {
            slot.GetComponent<Button>().onClick.AddListener(() => OnItemSlotClick(slot));
        }
    }

    public void AddItemToUI(Sprite itemIcon, Inventory.Item item)
    {
        foreach (UnityEngine.UI.Image slot in itemSlots)
        {
            if (slot.sprite == null)
            {
                slot.sprite = itemIcon;
                slot.enabled = true;
                slot.preserveAspect = true;
                itemSlotDictionary[slot] = item;
                break;
            }
        }
    }

    public void RemoveItemFromUI(Sprite itemIcon)
    {
        foreach (UnityEngine.UI.Image slot in itemSlots)
        {
            if (slot.sprite == itemIcon)
            {
                slot.sprite = null;
                slot.enabled = false;
                itemSlotDictionary.Remove(slot);
                break;
            }
        }
    }

    private void OnItemSlotClick(UnityEngine.UI.Image slot)
    {
        if (itemSlotDictionary.TryGetValue(slot, out Inventory.Item item))
        {
            ShowItemDescription(item);
        }
    }

    private void ShowItemDescription(Inventory.Item item)
    {
        itemDescriptionPanel.SetActive(true);
        itemNameText.text = item.name;
        itemDescriptionText.text = item.description;
    }

    public void CloseItemDescriptionPanel()
    {
        itemDescriptionPanel.SetActive(false);
    }
}
