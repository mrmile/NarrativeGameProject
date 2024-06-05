using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class Dial_Iris : NPC_UniqueDialogueHolder
{
    GameObject player;
    Char_Inventory playerInventory;

    [SerializeField] NPCConversation startGameConversation;

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
        ret.title = "Iris";


        return ret;
    }

    // Start is called before the first frame update
    void Start()
    {
        ConversationManager.Instance.StartConversation(startGameConversation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
