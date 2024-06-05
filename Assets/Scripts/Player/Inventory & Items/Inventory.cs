using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public enum ItemType
    {
        NoItem, Papers, Cinturon, Cura, Key, Pendiente, TarjetaAcceso, ClaveAcceso, TrajeOperaciones, Maletin, Linterna
    }

    [Serializable]
    public class Item
    {
        public ItemType type;
        public Sprite icon;
        public string name;
        public string description;
        public string pickUpText;
        public bool isEquipped;
    }

    [Serializable]
    public class Note
    {
        public string identifier;
        public string content;
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

        if (inventory != null && inventory != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        foreach (Item item in allItems)
        {
            if (item.icon == null) item.icon = defaultSprite;

            if (!itemsDictionary.ContainsKey(item.type))
            {
                itemsDictionary.Add(item.type, item);
                //Debug.Log("Added item of type " + item.type + " to itemsDictionary.");
            }
        }

        Debug.Log("Inventory initialized with " + itemsDictionary.Count + " items.");
    }

    public bool HasTarjetaAcceso()
    {
        return itemsDictionary.ContainsKey(ItemType.TarjetaAcceso);
    }

    public void UseTarjetaAcceso()
    {
        if (HasTarjetaAcceso())
        {
            itemsDictionary.Remove(ItemType.TarjetaAcceso);
        }
    }
}
