using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Char_Inventory : MonoBehaviour
{
    [SerializeField] public List<Inventory.Note> notes;
    [SerializeField] public List<Inventory.Item> items;
    [SerializeField] List<GameObject> collidingItems;
    [SerializeField] GameObject pickupCanvasPrefab;
    [SerializeField] GameObject flashlightObject;  // Reference to the GameObject that emits light
    private Dictionary<GameObject, GameObject> itemToCanvasMap = new Dictionary<GameObject, GameObject>();
    [SerializeField] GameObject noteHolder;
    [SerializeField] Inventory inventory;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }


    public bool CheckNotes(string identifier)
    {
        foreach (Inventory.Note id in notes)
        {
            if (id.identifier == identifier)
            {
                //Debug.Log(identifier + " FOUND");
                return true;

            }
        }
        return false;
    }

    public void AddNote(string identifier, string content)
    {
        //noteHolder = GameObject.Find("NoteHolder");
        //if (noteHolder == null)
        //{
        //    Debug.LogError("NoteHolder not found.");
        //    return;
        //}

        
        foreach (Inventory.Note  n in notes) // check if there is already a note with that identifier
        {
            if (n.identifier == identifier)
                return;
        }

        Inventory.Note note = new Inventory.Note(identifier, content);
        notes.Add(note);

        //GameObject n = Instantiate(inventory.notePrefab);
        //n.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = note.identifier;
        //n.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = note.content;

        //n.transform.parent = noteHolder.transform;
        //n.transform.localScale = new Vector3(1, 1, 1);
    }

    public void AddNote(Inventory.Note note)
    {
        //noteHolder = GameObject.Find("NoteHolder");
        //if (noteHolder == null)
        //{
        //    Debug.LogError("NoteHolder not found.");
        //    return;
        //}


        foreach (Inventory.Note n in notes) // check if there is already a note with that identifier
        {
            if (n.identifier == note.identifier)
                return;
        }

        
        notes.Add(note);

        
    }

    public bool CheckItem(Inventory.ItemType type)
    {
        foreach (Inventory.Item item in items)
        {
            if (item.type == type)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item_Scene item = collision.GetComponent<Item_Scene>();
        if (item != null && !collidingItems.Contains(collision.gameObject))
        {
            collidingItems.Add(collision.gameObject);
            ShowPickupCanvas(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Item_Scene item = collision.GetComponent<Item_Scene>();
        if (item != null && collidingItems.Contains(collision.gameObject))
        {
            collidingItems.Remove(collision.gameObject);
            HidePickupCanvas(collision.gameObject);
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = collidingItems.Count - 1; i >= 0; i--)
            {
                var go = collidingItems[i];
                Item_Scene itemScene = go.GetComponent<Item_Scene>();

                if (itemScene != null)
                {
                    collidingItems.RemoveAt(i);
                    Inventory.Item item = itemScene.Get();
                    if (item != null)
                    {
                        items.Add(item);
                        InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
                        if (inventoryUI != null)
                            inventoryUI.AddItemToUI(item.icon, item);
                        else
                            Debug.Log("Couldn't find InventoryUI");

                        HidePickupCanvas(go);
                    }
                    break;
                }
            }
        }

        // Check for equip action
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    foreach (var item in items)
        //    {
        //        if (item.type == Inventory.ItemType.Linterna)
        //        {
        //            EquipItem(item);
        //            break;
        //        }
        //    }
        //}
    }

    public void EquipItem(Inventory.Item item)
    {
        if (item.type == Inventory.ItemType.Linterna)
        {
            Debug.Log($"EquipItem method called. Current state of flashlight: {flashlightObject.activeSelf}");
            item.isEquipped = !item.isEquipped;
            flashlightObject.SetActive(item.isEquipped);  // Activate or deactivate the flashlight GameObject
            Debug.Log($"Flashlight state after toggling: {flashlightObject.activeSelf}");
        }
        else
        {
            Debug.Log("EquipItem called for non-Linterna item.");
        }
    }

    private void ShowPickupCanvas(GameObject item)
    {
        if (pickupCanvasPrefab != null)
        {
            GameObject canvasInstance = Instantiate(pickupCanvasPrefab, item.transform.position + Vector3.up * 0.5f, Quaternion.identity);
            canvasInstance.transform.SetParent(item.transform);
            itemToCanvasMap[item] = canvasInstance;
        }
    }

    private void HidePickupCanvas(GameObject item)
    {
        if (itemToCanvasMap.ContainsKey(item))
        {
            Destroy(itemToCanvasMap[item]);
            itemToCanvasMap.Remove(item);
        }
    }
}
