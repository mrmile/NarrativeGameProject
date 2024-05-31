using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFailBehaviour : MonoBehaviour
{
    //public bool airOff = false;

    public GameObject airEffect;
    int intensity = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AirFailBehaviourVariables.airOff == false && intensity <= 0)
        {
            intensity = 100;

            airEffect.SetActive(false);
        }
        if (AirFailBehaviourVariables.airOff == true && intensity > 0)
        {
            intensity = 0;

            airEffect.SetActive(true);
        }
    }
}
