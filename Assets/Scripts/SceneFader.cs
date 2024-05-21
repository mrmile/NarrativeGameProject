using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 2.0f; // Duration of the fade-in

    private void Start()
    {
        // Ensure the fadeImage starts fully opaque
        fadeImage.color = new Color(0, 0, 0, 1);
        // Start the fade-in coroutine
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1.0f - (elapsedTime / fadeDuration));
            fadeColor.a = alpha;
            fadeImage.color = fadeColor;
            yield return null;
        }

        // Ensure the fadeImage is fully transparent at the end of the fade
        fadeColor.a = 0;
        fadeImage.color = fadeColor;
        fadeImage.gameObject.SetActive(false); // Optionally deactivate the fade image after the fade-in
    }
}
