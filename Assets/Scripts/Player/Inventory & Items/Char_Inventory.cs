using System.Collections.Generic;
using UnityEngine;

public class Char_Inventory : MonoBehaviour
{
    [SerializeField] List<Inventory.Item> items;
    [SerializeField] List<GameObject> collidingItems;
    [SerializeField] GameObject pickupCanvasPrefab;
    [SerializeField] GameObject flashlightObject;  // Reference to the GameObject that emits light
    private Dictionary<GameObject, GameObject> itemToCanvasMap = new Dictionary<GameObject, GameObject>();

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
                    Inventory.Item item = itemScene.Get();
                    if (item != null)
                    {
                        items.Add(item);
                        InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
                        inventoryUI.AddItemToUI(item.icon, item);
                        HidePickupCanvas(go);
                        collidingItems.RemoveAt(i);
                    }
                    break;
                }
            }
        }
    }

    public void EquipItem(Inventory.Item item)
    {
        if (item.type == Inventory.ItemType.Linterna)
        {
            Debug.Log("EquipItem method called. Toggling flashlight.");
            item.isEquipped = !item.isEquipped;
            flashlightObject.SetActive(item.isEquipped);  // Activate or deactivate the flashlight GameObject
            Debug.Log("Flashlight enabled state: " + flashlightObject.activeSelf);
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
