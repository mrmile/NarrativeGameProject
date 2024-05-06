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

        //Debug.Log("Has Item 1: " + GameManager.Instance.hasItem1);
        ConversationManager.Instance.SetBool("hasItem1", GameManager.Instance.hasItem1);
        ConversationManager.Instance.SetBool("hasItem2", GameManager.Instance.hasItem2);
        ConversationManager.Instance.SetBool("hasItem3", GameManager.Instance.hasItem3);
    }

    public void StartDialogue()
{
    ConversationManager.Instance.StartConversation(introDialogue);
}

}
