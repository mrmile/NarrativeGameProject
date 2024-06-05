using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public struct NPC_ConversationInfo
{
    public string title;
    public Sprite sprite;
    public string content;
    public NPCConversation conversation;
}
public class NPC_UniqueDialogueHolder : MonoBehaviour // specific to each npc to inherit from.
{
    [SerializeField] protected NPCConversation nullConversation;
    [SerializeField] List<Inventory.Note> notesToGive;
    protected bool firstTalked = false;

    [SerializeField] protected Char_Inventory playerInventory;
    public virtual NPC_ConversationInfo GetConversation() // sould be overrided to return specific conversations with specific conditions for each npc
    {
        NPC_ConversationInfo ret = new NPC_ConversationInfo();
        ret.title = "Null";
        ret.content = "Conversation't";
        ret.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        return ret;
    }


    public void GiveNote(string identifier)
    {
        if (!playerInventory.CheckNotes(identifier))
        {
            Inventory.Note noteToGive = GetNote(identifier);
            if (noteToGive != null)
                playerInventory.notes.Add(noteToGive);
        }
    }

    public Inventory.Note GetNote(string identifier)
    {
        foreach (Inventory.Note id in notesToGive)
        {
            if (id.identifier == identifier)
                return id;
        }
        return null;
    }

}

public class DialogueHolder : MonoBehaviour // for every npc, it asks for conversations from an npc
{

    [SerializeField] bool dialogueActive;


    [SerializeField] NPC_UniqueDialogueHolder uniqueDialogueHolder;
    [SerializeField] NPCConversation nullConversation;

    // Start is called before the first frame update
    void Start()
    {


        uniqueDialogueHolder = GetComponent<NPC_UniqueDialogueHolder>();

        nullConversation = GameObject.Find("NullConversation").GetComponent<NPCConversation>();
    }

    public void StartDialogue()
    {
        dialogueActive = true;

        if (ConversationManager.Instance != null)
        {

            NPC_ConversationInfo conversationToShow = uniqueDialogueHolder.GetConversation();
            if (conversationToShow.conversation == null)
            {
                conversationToShow.conversation = nullConversation;
                Debug.LogError("No Conversation was found.");
            }
            ConversationManager.Instance.StartConversation(conversationToShow.conversation);
            ConversationManager.Instance.ReplaceIcon(conversationToShow.sprite);
            ConversationManager.Instance.OverrideName(conversationToShow.title);

        }
        else
        {
            Debug.LogError("ConversationManager instance is null.");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!ConversationManager.Instance.IsConversationActive && dialogueActive)
        {
            dialogueActive = false;
        }

        //if (movement != null)
        //    if (dialogueActive)
        //    {
        //        movement.isMoving = false;
        //    }
        //    else if (wasMoving)
        //    {
        //        movement.isMoving = true;
        //        wasMoving = false;
        //    }
    }
}
