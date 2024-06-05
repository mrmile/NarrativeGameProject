using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePersistent : MonoBehaviour
{
    private void Awake()
    {
        GameObject obj = GameObject.Find(gameObject.name);

        if (obj != null && obj != gameObject)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
