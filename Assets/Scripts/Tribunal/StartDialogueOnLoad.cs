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
        ConversationManager.Instance.SetBool("hasPapeles", GameManager.Instance.hasPapeles);
        ConversationManager.Instance.SetBool("hasCinturon", GameManager.Instance.hasCinturon);
        ConversationManager.Instance.SetBool("hasCura", GameManager.Instance.hasCura);
        ConversationManager.Instance.SetBool("hasPendiente", GameManager.Instance.hasPendiente);
        ConversationManager.Instance.SetBool("hasMaletin", GameManager.Instance.hasMaletin);
    }

    public void StartDialogue()
{
    ConversationManager.Instance.StartConversation(introDialogue);
}

}
