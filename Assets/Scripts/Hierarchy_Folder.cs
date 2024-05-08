using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hierarchy_Folder : MonoBehaviour
{

    // Does nothing but you can set gameobjects as children to organize the hierarchy.
    // Detaches children to avoid interacting with physics. 
    private void Awake()
    {
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
