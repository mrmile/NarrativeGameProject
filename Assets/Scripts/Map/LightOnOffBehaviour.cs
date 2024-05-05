using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOffBehaviour : MonoBehaviour
{
    public bool lightsOff = false;

    public GameObject[] lights;
    int intensity = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lightsOff == false && intensity <= 0)
        {
            intensity = 100;

            for(int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(true);
            }
        }
        if (lightsOff == true && intensity > 0)
        {
            intensity = 0;

            for (int j = 0; j < lights.Length; j++)
            {
                lights[j].SetActive(false);
            }
        }
    }
}
