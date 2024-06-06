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

        Char_Inventory player = GameObject.FindGameObjectWithTag("Player").GetComponent<Char_Inventory>();
        DialogueInteractions interactions = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogueInteractions>();
        switch (itemType)
        {
            case Inventory.ItemType.NoItem:
                break;
            case Inventory.ItemType.Papers:
                player.AddNote("Viktor's Letters", "These Letters seem to describe something called 'The Resistance'. They don't speak well about Bruce Miller.");

                break;
            case Inventory.ItemType.Cinturon:
                player.AddNote("Bruce's Belt", "This belt belongs to Bruce Miller. Is such a strange location to lose it...");
                break;
            case Inventory.ItemType.Cura:
                player.AddNote("Anti - Radiation Chemical", "The code seems to belong to a Chemical that increases resistance to Radiation.");
                break;
            case Inventory.ItemType.Key:
                break;
            case Inventory.ItemType.Pendiente:
                player.AddNote("Vera's earring", "Vera lost an earring in the Reactor. However, only Viktor and you have access to it.");
                break;
            case Inventory.ItemType.TarjetaAcceso:
                break;
            case Inventory.ItemType.ClaveAcceso:
                break;
            case Inventory.ItemType.TrajeOperaciones:
                break;
            case Inventory.ItemType.Maletin:
                interactions.hasMaletin = true;
                break;
            case Inventory.ItemType.Linterna:
                break;
            default:
                break;
        }

        Destroy(gameObject);
        return item;
    }
}

  