using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Inventory : MonoBehaviour
{
    [SerializeField] List<Inventory.Item> items;
    [SerializeField] List<GameObject> collidingItems;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item_Scene item = collision.GetComponent<Item_Scene>();
        if (item != null)
            collidingItems.Add(collision.gameObject);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Item_Scene item = collision.GetComponent<Item_Scene>();
        if (item != null) 
            collidingItems.Remove(collision.gameObject);
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
                inventoryUI.AddItemToUI(item.icon);
                GameManager.Instance.hasItem1 = true;
                Debug.Log("Item 1 picked up: " + GameManager.Instance.hasItem1);
                break;
            }
        }
    }
}


}
