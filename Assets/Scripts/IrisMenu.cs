using UnityEngine;
using UnityEngine.SceneManagement;

public class IrisMenu : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Tribunal");
    }
}