using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class NPC_UniqueDialogueHolder : MonoBehaviour // specific to each npc to inherit from.
{
    [SerializeField] protected NPCConversation nullConversation;

    public virtual NPCConversation GetConversation() // sould be overrided to return specific conversations with specific conditions for each npc
    {
        return nullConversation;
    }
}

public class DialogueHolder : MonoBehaviour // for every npc, it asks for conversations from an npc
{

    [SerializeField] bool dialogueActive;
    [SerializeField] Sprite sprite;
    [SerializeField] NPC_Movement movement;
    [SerializeField] NPC_UniqueDialogueHolder uniqueDialogueHolder;
    [SerializeField] NPCConversation nullConversation;

    bool wasMoving = false;

    // Start is called before the first frame update
    void Start()
    {

        movement = GetComponent<NPC_Movement>();
        uniqueDialogueHolder = GetComponent<NPC_UniqueDialogueHolder>();
        sprite = GetComponent<SpriteRenderer>().sprite;
        nullConversation = GameObject.Find("NullConversation").GetComponent<NPCConversation>();
    }

    public void StartDialogue()
    {
        dialogueActive = true;

        if (ConversationManager.Instance != null)
        {

            NPCConversation conversationToShow = uniqueDialogueHolder.GetConversation();
            if (conversationToShow == null)
            {
                conversationToShow = nullConversation;
                Debug.LogError("No Conversation was found.");
            }
            print(conversationToShow);
            ConversationManager.Instance.StartConversation(conversationToShow);
            ConversationManager.Instance.ReplaceIcon(sprite);
        }
        else
        {
            Debug.LogError("ConversationManager instance is null.");
        }
        if (movement.isMoving) wasMoving = true;
        else wasMoving = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!ConversationManager.Instance.IsConversationActive && dialogueActive)
        {
            dialogueActive = false;
        }

        if (dialogueActive)
        {
            movement.isMoving = false;
        }
        else if (wasMoving)
        {
            movement.isMoving = true;
            wasMoving = false;
        }
    }
}
