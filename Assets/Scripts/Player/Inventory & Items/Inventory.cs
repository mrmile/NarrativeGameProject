using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public GameObject notePrefab;
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

        public Note(string identifier, string content)
        {
            this.identifier = identifier;
            this.content = content;
        }
    }

    [SerializeField]
    Sprite defaultSprite;

    [SerializeField]
    public List<Item> allItems;

    [SerializeField]
    public List<Item> pickedUpItems = new List<Item>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Debug.Log("Inventory initialized with " + pickedUpItems.Count + " items.");
    }

    public void AddItem(Item item)
    {
        if (!pickedUpItems.Contains(item))
        {
            pickedUpItems.Add(item);
        }
    }

    public bool HasTarjetaAcceso()
    {
        return pickedUpItems.Exists(item => item.type == ItemType.TarjetaAcceso);
    }

    public void UseTarjetaAcceso()
    {
        pickedUpItems.RemoveAll(item => item.type == ItemType.TarjetaAcceso);
    }
}
