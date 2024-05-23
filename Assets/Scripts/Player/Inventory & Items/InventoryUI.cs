using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public UnityEngine.UI.Image[] itemSlots;
    public GameObject itemDescriptionPanel;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
    public Button equipButton; // Add this line

    private Dictionary<UnityEngine.UI.Image, Inventory.Item> itemSlotDictionary = new Dictionary<UnityEngine.UI.Image, Inventory.Item>();
    private Inventory.Item selectedItem; // Add this line to store the currently selected item

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

        equipButton.gameObject.SetActive(false); // Ensure the equip button is initially hidden
        equipButton.onClick.AddListener(OnEquipButtonClick); // Add this line to set up the button event
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
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => ShowItemDescription(item));
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
                button.onClick.RemoveAllListeners();
                break;
            }
        }
    }

    public void OnItemSlotClick(UnityEngine.UI.Image slot)
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
        selectedItem = item; // Store the selected item

        if (item.type == Inventory.ItemType.Linterna)
        {
            equipButton.gameObject.SetActive(true);
        }
        else
        {
            equipButton.gameObject.SetActive(false);
        }
    }

    public void CloseItemDescriptionPanel()
    {
        itemDescriptionPanel.SetActive(false);
        equipButton.gameObject.SetActive(false); // Hide equip button when closing panel
    }

    public void OnEquipButtonClick() // Add this method to handle button clicks
    {
        Char_Inventory charInventory = FindObjectOfType<Char_Inventory>();
        if (charInventory != null && selectedItem != null)
        {
            charInventory.EquipItem(selectedItem);
        }
    }
}
