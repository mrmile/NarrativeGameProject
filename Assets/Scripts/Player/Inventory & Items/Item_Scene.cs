using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Item_Scene : MonoBehaviour
{
    //to add items go to the script Inventory.cs -> enum ItemType
    public Inventory.ItemType itemType;
    Inventory.Item item;
    NPCConversation pickUpDialogue;

    Inventory inventory;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        pickUpDialogue = GameObject.Find("ItemPickUpDialogue").GetComponent<NPCConversation>();
        
    }

    public void Start()
    {
        if (inventory.itemsDictionary.ContainsKey(itemType))
            item = inventory.itemsDictionary[itemType];

        //set sprite here
        GetComponent<SpriteRenderer>().sprite = item.icon;
    }
    public Inventory.Item Get()
    {
        ConversationManager.Instance.StartConversation(pickUpDialogue);

        if (itemType == Inventory.ItemType.Item1)
        {
            GameManager.Instance.SetItem1(true);
        }

        if (item.pickUpText != "")
            ConversationManager.Instance.OverrideText(item.pickUpText);
        else
            ConversationManager.Instance.ReplaceText("itemName", item.name);
        

        ConversationManager.Instance.ReplaceIcon(item.icon);


        Destroy(gameObject);
        return item;
    }
}
