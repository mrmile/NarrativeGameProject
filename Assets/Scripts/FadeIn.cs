using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{ 
    public Animator animator;

    void Start()
    {
        Invoke("FadeOut", 2);
    }

    public void FadeOut()
    {
        animator.Play("FadeIn");
    }

    
}
