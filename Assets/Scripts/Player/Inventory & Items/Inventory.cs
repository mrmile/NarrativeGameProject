using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
   public enum ItemType
    {
        NoItem, Item1, Item2, Item3, Key
    }

    [Serializable]
    public class Item
    {
        public ItemType type;
        public Sprite icon;
        public string name;
        public string description;
        public string pickUpText;
    }

    [SerializeField]
    Sprite defaultSprite;

    [SerializeField]
    List<Item> allItems;

    [SerializeField]
    public Dictionary<ItemType, Item> itemsDictionary = new Dictionary<ItemType, Item>();


    private void Awake()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

        if (inventory != null) Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        foreach (Item item in allItems)
        {
            if (item.icon == null) item.icon = defaultSprite;

            if (!itemsDictionary.ContainsKey(item.type))
                itemsDictionary.Add(item.type, item);
        }
    }

}
