using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Inventory
{
   public enum ItemType
    {
        NoItem, Item1, Item2, Item3
    }

    [Serializable]
    public class Item
    {
        public ItemType type;
        public string name;
        public string description;
        public string pickUpText;
    }
}
