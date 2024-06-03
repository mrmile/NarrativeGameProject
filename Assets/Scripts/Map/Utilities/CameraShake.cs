using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    public Camera camera;
    private Vector3 originalCameraPosition;

    public void ShakeCamera(float duration, float intensity)
    {
        StartCoroutine(Shake(duration, intensity));
    }

    IEnumerator Shake(float duration, float intensity)
    {
        originalCameraPosition = camera.transform.position;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate a random offset within the specified intensity
            Vector3 offset = new Vector3(Random.Range(-1f, 1f) * intensity, Random.Range(-1f, 1f) * intensity, 0f);

            // Apply the offset to the camera's position
            camera.transform.position = originalCameraPosition + offset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly the original position
        camera.transform.position = originalCameraPosition;
    }
}
