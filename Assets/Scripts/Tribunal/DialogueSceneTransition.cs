using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueSceneTransition : MonoBehaviour
{
    // Public field to set the scene name in the Inspector
    public string nextSceneName;

    // Method to call when the dialogue is finished
    public void OnDialogueComplete()
    {
        // Check if the scene name is not empty
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            // Load the scene
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set!");
        }
    }
}