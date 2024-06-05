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
    public Button equipButton;

    private Dictionary<UnityEngine.UI.Image, Inventory.Item> itemSlotDictionary = new Dictionary<UnityEngine.UI.Image, Inventory.Item>();
    private Inventory.Item selectedItem;

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

        equipButton.gameObject.SetActive(false);
        equipButton.onClick.AddListener(OnEquipButtonClick);

        LoadItemsToUI();  // Load items when the scene starts
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

                Debug.Log(slot.gameObject);
                Button button = slot.gameObject.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.RemoveAllListeners();
                    button.onClick.AddListener(() => ShowItemDescription(item));
                }
                else
                {
                    Debug.Log("button not found");
                }

                break;
            }
        }
    }

    public void RemoveItemFromUI(Inventory.ItemType itemType)
    {
        foreach (var kvp in itemSlotDictionary)
        {
            if (kvp.Value.type == itemType)
            {
                UnityEngine.UI.Image slot = kvp.Key;
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
        selectedItem = item;

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
        equipButton.gameObject.SetActive(false);
    }

    public void OnEquipButtonClick()
    {
        Char_Inventory charInventory = FindObjectOfType<Char_Inventory>();
        if (charInventory != null && selectedItem != null)
        {
            charInventory.EquipItem(selectedItem);
        }
    }

    private void LoadItemsToUI()
    {
        foreach (var item in Inventory.Instance.pickedUpItems)
        {
            AddItemToUI(item.icon, item);
        }
    }
}
