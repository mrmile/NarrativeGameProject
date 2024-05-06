using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool hasItem1 = false;
    public bool hasItem2 = false;
    public bool hasItem3 = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetItem(Inventory.ItemType itemType, bool value)
    {
        switch (itemType)
        {
            case Inventory.ItemType.Item1:
                hasItem1 = value;
                Debug.Log("Item 1 set to: " + value);
                break;
            case Inventory.ItemType.Item2:
                hasItem2 = value;
                Debug.Log("Item 2 set to: " + value);
                break;
            case Inventory.ItemType.Item3:
                hasItem3 = value;
                Debug.Log("Item 3 set to: " + value);
                break;
        }
        Debug.Log("Item " + itemType + " set to: " + value);
    }
}