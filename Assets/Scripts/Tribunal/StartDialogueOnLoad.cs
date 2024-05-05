using UnityEngine;
using DialogueEditor;

public class StartDialogueOnLoad : MonoBehaviour
{
    public NPCConversation introDialogue;

    void Start()
    {
        if (introDialogue != null)
        {
            ConversationManager.Instance.StartConversation(introDialogue);
        }
    }
}
