using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool hasPapeles = false;
    public bool hasCinturon = false;
    public bool hasCura = false;
    public bool hasPendiente = false;
    public bool hasMaletin = false;

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
            case Inventory.ItemType.Papers:
                hasPapeles = value;
                break;
            case Inventory.ItemType.Cinturon:
                hasCinturon = value;
                break;
            case Inventory.ItemType.Cura:
                hasCura = value;
                break;
            case Inventory.ItemType.Pendiente:
                hasPendiente = value;
                break;
                case Inventory.ItemType.Maletin:
                hasMaletin = value;
                break;
        }
        //Debug.Log("Item " + itemType + " set to: " + value);
    }
}