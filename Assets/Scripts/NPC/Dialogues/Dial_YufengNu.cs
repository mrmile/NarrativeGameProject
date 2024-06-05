using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class Dial_YufengNu : NPC_UniqueDialogueHolder
{
    GameObject player;
    Char_Inventory playerInventory;

    [SerializeField] NPCConversation defaultConversation;
    [SerializeField] NPCConversation dialogue1;
    [SerializeField] NPCConversation dialogue2;

    int rand;
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
        ret.title = "Yufeng Nu";

        rand = Random.Range(1, 3);
        //if (playerInventory.CheckItem(Inventory.ItemType.Maletin)) return dialogue1;
        if (rand == 1) ret.conversation = dialogue1;
        if (rand == 2) ret.conversation = dialogue2;

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
