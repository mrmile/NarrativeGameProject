using UnityEngine;
using DialogueEditor;

public class Item_Scene : MonoBehaviour
{
    public Inventory.ItemType itemType;
    private Inventory.Item item;
    private NPCConversation pickUpDialogue;
    private Inventory inventory;

    public GameObject pickupPrompt;
    private bool isPlayerInRange = false;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        pickUpDialogue = GameObject.Find("ItemPickUpDialogue").GetComponent<NPCConversation>();
        Debug.Log("Awake: Inventory and pickUpDialogue initialized.");
    }

    private void Start()
    {
        if (inventory.itemsDictionary.ContainsKey(itemType))
            item = inventory.itemsDictionary[itemType];

        GetComponent<SpriteRenderer>().sprite = item.icon;

        if (pickupPrompt != null)
        {
            pickupPrompt.SetActive(false);
            Debug.Log("Start: pickupPrompt set to inactive.");
        }
        else
        {
            Debug.LogWarning("Start: pickupPrompt is not assigned.");
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Update: Player pressed E.");
            Get();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            isPlayerInRange = true;
            if (pickupPrompt != null)
            {
                pickupPrompt.SetActive(true);
                Debug.Log("OnTriggerEnter: pickupPrompt set to active.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger");
            isPlayerInRange = false;
            if (pickupPrompt != null)
            {
                pickupPrompt.SetActive(false);
                Debug.Log("OnTriggerExit: pickupPrompt set to inactive.");
            }
        }
    }

    public Inventory.Item Get()
    {
        ConversationManager.Instance.StartConversation(pickUpDialogue);

        GameManager.Instance.SetItem(itemType, true);

        if (item.pickUpText != "")
            ConversationManager.Instance.OverrideText(item.pickUpText);
        else
            ConversationManager.Instance.ReplaceText("itemName", item.name);

        ConversationManager.Instance.ReplaceIcon(item.icon);

        Destroy(gameObject);
        return item;
    }
}
