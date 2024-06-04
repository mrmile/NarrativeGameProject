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
    [SerializeField] string name;
    [SerializeField] bool dialogueActive;
    [SerializeField] Sprite sprite;
    [SerializeField] NPC_Movement movement;
    [SerializeField] NPC_UniqueDialogueHolder uniqueDialogueHolder;

    // Start is called before the first frame update
    void Start()
    {

        movement = GetComponent<NPC_Movement>();
        uniqueDialogueHolder = GetComponent<NPC_UniqueDialogueHolder>();
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    public void StartDialogue()
    {
        dialogueActive = true;

        if (ConversationManager.Instance != null)
        {

            NPCConversation conversationToShow = uniqueDialogueHolder.GetConversation();
            if (conversationToShow != null)
            {
                print(sprite);
                ConversationManager.Instance.ReplaceIcon(sprite);
                ConversationManager.Instance.StartConversation(conversationToShow);

            }
        }
        else
        {
            Debug.LogError("ConversationManager instance is null.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive)
        {
            movement.isMoving = false;
        }
    }
}
