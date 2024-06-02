using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ReactorFailBehavior : MonoBehaviour
{
    public GameObject reactorEffect;
    int intensity = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ReactorFailBehaviorVariables.reactorOff == false && intensity <= 0)
        {
            intensity = 100;

            reactorEffect.SetActive(false);
        }
        if (ReactorFailBehaviorVariables.reactorOff == true && intensity > 0)
        {
            intensity = 0;

            reactorEffect.SetActive(true);
        }
    }
}
