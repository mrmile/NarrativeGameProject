using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ComunicationsFailBehavior : MonoBehaviour
{
    public GameObject staticEffect;
    int intensity = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ComunicationsFailBehaviorVariables.comunicationsOff == false && intensity <= 0)
        {
            intensity = 100;

            staticEffect.SetActive(false);
        }
        if (ComunicationsFailBehaviorVariables.comunicationsOff && intensity > 0)
        {
            intensity = 0;

            staticEffect.SetActive(true);
        }
    }
}
