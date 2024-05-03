using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Item_Scene : MonoBehaviour
{
    //to add items go to the script Inventory.cs -> enum ItemType
    public Inventory.Item item;
    [SerializeField] NPCConversation pickUpDialogue;

    public void Start()
    {
        //set sprite here
        

        //
    }
    public Inventory.Item Get()
    {
        ConversationManager.Instance.StartConversation(pickUpDialogue);
        //ConversationManager.Instance.OverrideText(item.pickUpText);
        ConversationManager.Instance.ReplaceText("itemName", item.name);
        Destroy(gameObject);
        return item;
    }
}
