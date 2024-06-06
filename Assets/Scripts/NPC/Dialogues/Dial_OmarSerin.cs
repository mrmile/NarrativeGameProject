using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class Dial_OmarSerin : NPC_UniqueDialogueHolder
{
    DialogueInteractions playerInteractions;


    [SerializeField] NPCConversation FirstConversation;
    [SerializeField] NPCConversation basic1;

    private void Awake()
    {
        nullConversation = GameObject.Find("NullConversation").GetComponent<NPCConversation>();
        playerInteractions = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogueInteractions>();
        playerInventory = playerInteractions.gameObject.GetComponent<Char_Inventory>();
    }

    public override NPC_ConversationInfo GetConversation()
    {
        NPC_ConversationInfo ret = new NPC_ConversationInfo();

        ret.sprite = GetComponent<SpriteRenderer>().sprite;
        ret.title = "Omar Serin";

        ret.conversation = basic1;


        if (!playerInteractions.firstOmar)
        {
            ret.conversation = FirstConversation;
            playerInteractions.firstOmar = true;
        }

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
