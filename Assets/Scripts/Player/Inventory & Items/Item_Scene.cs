using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Scene : MonoBehaviour
{
    //to add items go to the script Inventory.cs -> enum ItemType
    public Inventory.Item item;

    public void Start()
    {
        //set sprite here
    }
    public Inventory.Item Get()
    {
        Destroy(gameObject);
        return item;
    }
}
