using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
            Button button = slot.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnItemSlotClick(slot));
            }
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

                Button button = slot.GetComponent<Button>();
                button.onClick.RemoveAllListeners(); // Remove previous listeners
                button.onClick.AddListener(() => ShowItemDescription(item)); // Add listener to show item description
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

                Button button = slot.GetComponent<Button>();
                button.onClick.RemoveAllListeners(); // Remove listeners to avoid calling on a null item
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

    public void ShowItemDescription(Inventory.Item item)
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
