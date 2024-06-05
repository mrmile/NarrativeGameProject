using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class Dial_TinoReimer : NPC_UniqueDialogueHolder
{
    GameObject player;
    Char_Inventory playerInventory;

    [SerializeField] NPCConversation defaultConversation;
    [SerializeField] NPCConversation dialogue1;
    [SerializeField] NPCConversation dialogue2;
    private void Awake()
    {
        nullConversation = GameObject.Find("NullConversation").GetComponent<NPCConversation>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<Char_Inventory>();
    }

    public override NPC_ConversationInfo GetConversation()
    {
        NPC_ConversationInfo ret = new NPC_ConversationInfo();

        ret.sprite = GetComponent<SpriteRenderer>().sprite;
        ret.title = "Tino Reimer";

        //if (playerInventory.CheckItem(Inventory.ItemType.Maletin)) return dialogue1;
        if (playerInventory.CheckItem(Inventory.ItemType.Maletin)) ret.conversation = dialogue1;
        if (playerInventory.CheckItem(Inventory.ItemType.Papers)) ret.conversation = dialogue2;

        return ret;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
