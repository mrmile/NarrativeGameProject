using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Item_Scene : MonoBehaviour
{
    // To add items go to the script Inventory.cs -> enum ItemType
    public Inventory.ItemType itemType;
    Inventory.Item item;
    NPCConversation pickUpDialogue;

    Inventory inventory;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        pickUpDialogue = GameObject.Find("ItemPickUpDialogue").GetComponent<NPCConversation>();
    }

    private void Start()
    {
        if (inventory.itemsDictionary.ContainsKey(itemType))
        {
            item = inventory.itemsDictionary[itemType];
            // Set sprite here if item is found
            GetComponent<SpriteRenderer>().sprite = item.icon;
        }
        else
        {
            Debug.LogError("Item of type " + itemType + " not found in inventory.");
        }
    }

    public Inventory.Item Get()
    {
        if (item == null)
        {
            Debug.LogError("Item is null. Cannot pick up.");
            return null;
        }

        if (ConversationManager.Instance != null)
        {
            ConversationManager.Instance.StartConversation(pickUpDialogue);

            if (!string.IsNullOrEmpty(item.pickUpText))
                ConversationManager.Instance.OverrideText(item.pickUpText);
            else
                ConversationManager.Instance.ReplaceText("itemName", item.name);

            ConversationManager.Instance.ReplaceIcon(item.icon);
        }
        else
        {
            Debug.LogError("ConversationManager instance is null.");
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetItem(itemType, true);
        }
        else
        {
            Debug.LogError("GameManager instance is null.");
        }

        Destroy(gameObject);
        return item;
    }
}
