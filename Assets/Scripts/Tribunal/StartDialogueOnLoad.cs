using UnityEngine;
using DialogueEditor;

public class StartDialogueOnLoad : MonoBehaviour
{
    public NPCConversation introDialogue;
    Char_Inventory player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Char_Inventory>();
        if (introDialogue != null)
        {
            ConversationManager.Instance.StartConversation(introDialogue);
        }

        Debug.Log("Has Item 1: " + player.CheckNotes("Lost Belt"));
        ConversationManager.Instance.SetBool("ViktorLetters", player.CheckNotes("Viktor's Letters"));
        ConversationManager.Instance.SetBool("antiRadiation", player.CheckNotes("Anti-Radiation Chemical"));
        ConversationManager.Instance.SetBool("BruceBelt", player.CheckNotes("Bruce's Belt"));
        ConversationManager.Instance.SetBool("lostBelt", player.CheckNotes("Lost Belt"));
        ConversationManager.Instance.SetBool("VerasEarring", player.CheckNotes("Vera's earring"));
        ConversationManager.Instance.SetBool("TinosGossip", player.CheckNotes("Tino's Gossip: Bruce"));
        ConversationManager.Instance.SetBool("lostChemical", player.CheckNotes("Lost Chemical"));

    }

    public void StartDialogue()
{
    ConversationManager.Instance.StartConversation(introDialogue);
}

}
