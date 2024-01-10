using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class InteractiveController : MonoBehaviour
{
    private Animator objectAnimation;
    private bool isOpen = false;

    private void Awake()
    {
        objectAnimation = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!isOpen)
        {
            objectAnimation.Play("OPEN",0,0.0f);
            isOpen = true;
        }
    }
}
