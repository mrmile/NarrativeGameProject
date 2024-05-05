using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Image[] itemSlots;

    public void AddItemToUI(Sprite itemIcon)
    {
        foreach (Image slot in itemSlots)
        {
            if (slot.sprite == null)
            {
                slot.sprite = itemIcon;
                slot.enabled = true;
                slot.preserveAspect = true;
                break;
            }
        }
    }

    public void RemoveItemFromUI(Sprite itemIcon)
    {
        foreach (Image slot in itemSlots)
        {
            if (slot.sprite == itemIcon)
            {
                slot.sprite = null;
                slot.enabled = false;
                break;
            }
        }
    }
}