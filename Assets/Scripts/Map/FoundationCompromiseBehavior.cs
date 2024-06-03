using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class FoundationCompromiseBehavior : MonoBehaviour
{
    //public GameObject airEffect;
    int intensity = 100;

    public AudioClip crackMetalSound;
    public AudioClip[] foundationsCrackSounds;
    AudioSource audioSource;

    CameraShake cameraShake_;
    bool turnItOn = false;
    public float minEffectDelay = 10;
    public float maxEffectDelay = 20;
    public float cameraShakeIntensity = 0.5f;
    public float cameraShakeDuration = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cameraShake_ = GetComponent<CameraShake>();

    }

    // Update is called once per frame
    void Update()
    {
        turnItOn = FoundationsCompBehaviorVariables.foundationsCompromised;

        if (FoundationsCompBehaviorVariables.foundationsCompromised == false && intensity <= 0)
        {
            intensity = 100;

            turnItOn = FoundationsCompBehaviorVariables.foundationsCompromised;

            StopCoroutine(PlayFoundationEffect(5, 10));
        }
        if (FoundationsCompBehaviorVariables.foundationsCompromised == true && intensity > 0)
        {
            intensity = 0;

            turnItOn = FoundationsCompBehaviorVariables.foundationsCompromised;

            audioSource.PlayOneShot(crackMetalSound);
            cameraShake_.ShakeCamera(cameraShakeDuration, cameraShakeIntensity);
            StartCoroutine(PlayFoundationEffect(5, 10));
        }
    }

    IEnumerator PlayFoundationEffect(float minTime_, float maxTime_) //Utilized better with a globalized variable
    {
        while (turnItOn == true)
        {
            float waitTime = Random.Range(minTime_, maxTime_);
            yield return new WaitForSeconds(waitTime);

            if (foundationsCrackSounds.Length > 0 && turnItOn == true)
            {
                int randomIndex = Random.Range(0, foundationsCrackSounds.Length);
                AudioClip randomClip = foundationsCrackSounds[randomIndex];
                audioSource.PlayOneShot(randomClip);
                cameraShake_.ShakeCamera(cameraShakeDuration, cameraShakeIntensity);
            }
        }
    }
}
