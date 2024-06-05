using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Item_Scene : MonoBehaviour
{
    public Inventory.ItemType itemType;
    Inventory.Item item;
    private NPCConversation pickUpDialogue;
    private Inventory inventory;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (player.GetComponent<Char_Inventory>().CheckItem(itemType))
                Destroy(gameObject);
        }

        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogError("Inventory not found with tag 'Inventory'.");
        }

        pickUpDialogue = GameObject.Find("ItemPickUpDialogue").GetComponent<NPCConversation>();
        if (pickUpDialogue == null)
        {
            Debug.LogError("ItemPickUpDialogue not found in the scene.");
        }
    }

    private void Start()
    {
        if (inventory != null)
        {
            item = inventory.allItems.Find(i => i.type == itemType);
            if (item != null)
            {
                GetComponent<SpriteRenderer>().sprite = item.icon;
            }
            else
            {
                Debug.LogError("Item of type " + itemType + " not found in inventory.");
            }
        }
        else
        {
            Debug.LogError("Inventory is null.");
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

        if (Inventory.Instance != null)
        {
            Inventory.Instance.AddItem(item);
        }
        else
        {
            Debug.LogError("Inventory instance is null.");
        }

        Destroy(gameObject);
        return item;
    }
}
