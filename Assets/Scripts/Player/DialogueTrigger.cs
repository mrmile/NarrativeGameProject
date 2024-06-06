using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> collidingNpcs;

    GameObject dialoguePanel;
    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel = ConversationManager.Instance.DialoguePanel.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && !dialoguePanel.activeSelf)
        {
            if (collidingNpcs.Count > 0)
            {
                DialogueHolder holder = collidingNpcs[0].GetComponent<DialogueHolder>();
                holder.StartDialogue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC" && !collidingNpcs.Contains(collision.gameObject))
        {
            collidingNpcs.Add(collision.gameObject);
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collidingNpcs.Contains(collision.gameObject))
        {
            collidingNpcs.Remove(collision.gameObject);
        }
    }
}
