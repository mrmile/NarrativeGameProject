using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip[] sounds; // Array of sounds to play
    public float minTime = 1.0f; // Minimum time interval
    public float maxTime = 5.0f; // Maximum time interval
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        //StartCoroutine(PlayRandomSound(test));
    }

    public IEnumerator PlayRandomSound(bool spawningCondition) //Utilized better with a globalized variable
    {
        while (spawningCondition == true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            if (sounds.Length > 0)
            {
                int randomIndex = Random.Range(0, sounds.Length);
                AudioClip randomClip = sounds[randomIndex];
                audioSource.PlayOneShot(randomClip);
            }
        }
    }
}

