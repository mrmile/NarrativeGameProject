using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(string sceneName)
    {
        // Load the specified scene by name
        SceneManager.LoadScene("MapLevel_0");
    }

    public void ExitGame()
    {
        // Quit the application using the full namespace for clarity
        UnityEngine.Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
