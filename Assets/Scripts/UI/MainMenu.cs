using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    private VideoPlayer introVideoPlayer;
    private Canvas mainMenuCanvas;

    private void Start()
    {
        // Find the VideoPlayer and Canvas in the scene
        introVideoPlayer = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();
        mainMenuCanvas = GetComponentInParent<Canvas>();

        if (introVideoPlayer != null)
        {
            introVideoPlayer.loopPointReached += OnIntroVideoFinished;
        }
    }

    public void StartGame()
    {
        if (introVideoPlayer != null)
        {
            mainMenuCanvas.enabled = false; // Hide the main menu canvas
            introVideoPlayer.Play();
        }
        else
        {
            LoadScene("MapLevel_0");
        }
    }

    private void OnIntroVideoFinished(VideoPlayer vp)
    {
        LoadScene("MapLevel_0");
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        UnityEngine.Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}