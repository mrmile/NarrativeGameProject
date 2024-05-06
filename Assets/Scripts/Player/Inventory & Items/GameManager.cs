using UnityEngine;  // This imports the Unity Engine namespace which includes MonoBehaviour

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Define other properties related to game state here
    public bool hasItem1 = false;

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance != null)
        {
            Destroy(gameObject);  // Destroy duplicate
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Make this object persistent across scenes
        }
    }

    // Example method to set item states
    public void SetItem1(bool value)
    {
        hasItem1 = value;
    }
}
