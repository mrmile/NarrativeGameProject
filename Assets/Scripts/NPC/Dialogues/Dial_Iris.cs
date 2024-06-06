using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class Dial_Iris : NPC_UniqueDialogueHolder
{
    DialogueInteractions playerInteractions;


    [SerializeField] bool startConversationActive;
    [SerializeField] bool startConversationCompleted = false;
    [SerializeField] NPCConversation startGameConversation;
    [SerializeField] NPCConversation debugStartConversation;
    [SerializeField] NPCConversation talk;
    [SerializeField] GameObject irisMenu;

    private void Awake()
    {
        GameObject iris = GameObject.Find("Iris");

        if (iris != null && iris != gameObject)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        nullConversation = GameObject.Find("NullConversation").GetComponent<NPCConversation>();
        playerInteractions = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogueInteractions>();
        playerInventory = playerInteractions.gameObject.GetComponent<Char_Inventory>();
    }

    public void Talk()
    {
        irisMenu.SetActive(false);
        playerInteractions.firstIris = true;
        ConversationManager.Instance.StartConversation(talk);
    }

    public override NPC_ConversationInfo GetConversation()
    {
        NPC_ConversationInfo ret = new NPC_ConversationInfo();

        ret.sprite = GetComponent<SpriteRenderer>().sprite;
        ret.title = "Iris";


        return ret;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!startConversationCompleted)
            if (startConversationActive)
                ConversationManager.Instance.StartConversation(startGameConversation);
            else
                ConversationManager.Instance.StartConversation(debugStartConversation);

        startConversationCompleted = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
