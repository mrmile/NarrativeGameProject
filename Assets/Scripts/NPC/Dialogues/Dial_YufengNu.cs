using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class Dial_YufengNu : NPC_UniqueDialogueHolder
{
    DialogueInteractions playerInteractions;



    [SerializeField] NPCConversation FirstConversation;

    [SerializeField] NPCConversation dialogue1;
    [SerializeField] NPCConversation dialogue2;

    int rand;

    
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
        ret.title = "Yufeng Nu";


        rand = Random.Range(0, 2);
        ret.conversation = (rand == 1) ? dialogue1 : dialogue2;

        if (!playerInteractions.firstYufeng)
        {
            ret.conversation = FirstConversation;
            playerInteractions.firstYufeng = true;
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
