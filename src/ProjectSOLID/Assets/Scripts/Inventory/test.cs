using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private Item itemToPush, pickedItem;
    
    //[SerializeField] private IventorySlot slot;

    private Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        Add();
    }

    [ContextMenu("Test push")]
    private void Add()
    {
        itemToPush = inventory.AddItem(itemToPush);
    }
    
    [ContextMenu("Test pick")]
    private void pick()
    {
        pickedItem = inventory.PickItem(pickedItem);
    }
}
