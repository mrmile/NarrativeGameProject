using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceAudioPlayer : MonoBehaviour
{
    public AudioClip Level_Pmin2_ambience;
    public AudioClip Level_Pmin1_ambience;
    public AudioClip Level_P0_ambience;
    public AudioClip lightsOffAmbience;
    AudioSource audioSource;

    MapEventsManager mapEventsManager_;

    public bool ambiencePlaying = false;
    public bool ambiencePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mapEventsManager_ = FindObjectOfType<MapEventsManager>();

        ambiencePlaying = false;

        if (EventManagerVariables.lightSwitchActive_1 == false ||
        EventManagerVariables.lightSwitchActive_2 == false ||
        EventManagerVariables.lightSwitchActive_3 == false ||
        EventManagerVariables.lightsOffEventActive == true)
        {
            ambiencePlaying = true;
            SwitchToLightsOffAmbience();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ambiencePlaying == false && ambiencePaused == false)
        {
            audioSource.loop = true;

            if(mapEventsManager_.currentMapLevel == 0)
            {
                audioSource.clip = Level_P0_ambience;
                audioSource.Play();
            }
            else if (mapEventsManager_.currentMapLevel == -1)
            {
                audioSource.clip = Level_Pmin1_ambience;
                audioSource.Play();
            }
            else if (mapEventsManager_.currentMapLevel == -2)
            {
                audioSource.clip = Level_Pmin2_ambience;
                audioSource.Play();
            }
            else if (mapEventsManager_.currentMapLevel == 1)
            {
                //nothing for now
                //audioSource.clip = Level_P1_ambience;
                //audioSource.Play();
            }

            ambiencePlaying = true;
        }
    }

    public void StopAudioAmbience()
    {
        audioSource.Stop();
        ambiencePlaying = false;
        ambiencePaused = true;
    }

    public void ResumeAudioAmbience()
    {
        audioSource.Play();
        ambiencePlaying = true;
        ambiencePaused = false;
    }

    public void SwitchToLightsOffAmbience()
    {
        //audioSource.Stop();
        audioSource.clip = lightsOffAmbience;
        audioSource.Play();
    }

    public void SwitchBackToDefaultAmbience()
    {
        //audioSource.Stop();
        if (mapEventsManager_.currentMapLevel == 0)
        {
            audioSource.clip = Level_P0_ambience;
            audioSource.Play();
        }
        else if (mapEventsManager_.currentMapLevel == -1)
        {
            audioSource.clip = Level_Pmin1_ambience;
            audioSource.Play();
        }
        else if (mapEventsManager_.currentMapLevel == -2)
        {
            audioSource.clip = Level_Pmin2_ambience;
            audioSource.Play();
        }
        else if (mapEventsManager_.currentMapLevel == 1)
        {
            //nothing for now
            //audioSource.clip = Level_P1_ambience;
            //audioSource.Play();
        }
        //audioSource.Play();
    }
}
