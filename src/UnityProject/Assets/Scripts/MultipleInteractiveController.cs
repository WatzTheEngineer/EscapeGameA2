using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Utils;

public class MultipleInteractiveController : MonoBehaviour,Raycastable
{
    [SerializeField] private GameObject nextObject;
    private Animator objectAnimation;
    private bool isOpen = false;
    [SerializeField] private GameObject[] triggeredObjects;

    private void Awake()
    {
        objectAnimation = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!isOpen)
        {
            objectAnimation.Play("OPEN",0,0.0f);
            nextObject.GetComponent<Raycastable>().PlayAnimation();
            isOpen = true;
            foreach (var obj in triggeredObjects)
            {
                obj.GetComponent<ITriggerable>().Trigger();
            }
        }
    }
}
