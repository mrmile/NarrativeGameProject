using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class Dial_ViktorYakovenko : NPC_UniqueDialogueHolder
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

    public override NPCConversation GetConversation()
    {

        if (playerInventory.CheckItem(Inventory.ItemType.Maletin)) return dialogue1;
        if (playerInventory.CheckItem(Inventory.ItemType.Papers)) return dialogue2;

        return defaultConversation;
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
