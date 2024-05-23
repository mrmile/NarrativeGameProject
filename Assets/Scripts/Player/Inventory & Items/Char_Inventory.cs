using System.Collections.Generic;
using UnityEngine;

public class Char_Inventory : MonoBehaviour
{
    [SerializeField] List<Inventory.Item> items;
    [SerializeField] List<GameObject> collidingItems;
    [SerializeField] GameObject pickupCanvasPrefab;  // Reference to the Canvas prefab
    private Dictionary<GameObject, GameObject> itemToCanvasMap = new Dictionary<GameObject, GameObject>();  // Map items to their Canvas instances

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item_Scene item = collision.GetComponent<Item_Scene>();
        if (item != null)
        {
            collidingItems.Add(collision.gameObject);
            ShowPickupCanvas(collision.gameObject);  // Show the pickup Canvas near the item
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Item_Scene item = collision.GetComponent<Item_Scene>();
        if (item != null)
        {
            collidingItems.Remove(collision.gameObject);
            HidePickupCanvas(collision.gameObject);  // Hide the Canvas when leaving the item's vicinity
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var go in collidingItems)
            {
                Item_Scene itemScene = go.GetComponent<Item_Scene>();

                if (itemScene != null)
                {
                    Inventory.Item item = itemScene.Get();
                    items.Add(item);
                    InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
                    inventoryUI.AddItemToUI(item.icon, item);
                    HidePickupCanvas(go);  // Hide the Canvas after picking up the item
                    collidingItems.Remove(go);  // Remove the picked-up item from the list
                    break;
                }
            }
        }
    }

    private void ShowPickupCanvas(GameObject item)
    {
        if (pickupCanvasPrefab != null)
        {
            GameObject canvasInstance = Instantiate(pickupCanvasPrefab, item.transform.position + Vector3.up * 0.5f, Quaternion.identity);
            canvasInstance.transform.SetParent(item.transform);  // Make the Canvas a child of the item
            itemToCanvasMap[item] = canvasInstance;  // Add to the map
        }
    }

    private void HidePickupCanvas(GameObject item)
    {
        if (itemToCanvasMap.ContainsKey(item))
        {
            Destroy(itemToCanvasMap[item]);  // Destroy the Canvas instance
            itemToCanvasMap.Remove(item);  // Remove from the map
        }
    }
}
