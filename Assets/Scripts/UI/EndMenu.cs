using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public VideoPlayer endingVideoPlayer;
    public Canvas endMenuCanvas;
    public Button exitGameButton;

    private void Start()
    {
        // Ensure the VideoPlayer, Canvas, and Button are set in the Inspector
        if (endingVideoPlayer == null)
        {
            Debug.LogError("VideoPlayer not assigned in the Inspector.");
        }
        else
        {
            endingVideoPlayer.loopPointReached += OnEndingVideoFinished;
        }

        if (endMenuCanvas == null)
        {
            Debug.LogError("Canvas not assigned in the Inspector.");
        }

        if (exitGameButton == null)
        {
            Debug.LogError("ExitGameButton not assigned in the Inspector.");
        }
        else
        {
            exitGameButton.gameObject.SetActive(false); // Hide the ExitGame button initially
        }
    }

    public void PlayEndingVideo()
    {
        if (endingVideoPlayer != null)
        {
            endMenuCanvas.enabled = false; // Hide the end menu canvas
            endingVideoPlayer.Play();
        }
    }

    private void OnEndingVideoFinished(VideoPlayer vp)
    {
        ShowEndOptions();
    }

    private void ShowEndOptions()
    {
        endMenuCanvas.enabled = true; // Show the end menu canvas
        if (exitGameButton != null)
        {
            exitGameButton.gameObject.SetActive(true); // Show the ExitGame button
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}