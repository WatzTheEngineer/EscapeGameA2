using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public struct Item
{
    [SerializeField] private int count;
    [SerializeField] private ItemData data;

    public void merge(ref Item other)
    {
        if (Full) return;

        if (Empty) data = other.data;
        
        if (other.data != data) throw new System.Exception("Try to merge different item types");

        int total = other.count + count;

        if (total < data.stackMaxCount)
        {
            count = total;
            other.count = 0;
            return;
        }

        count = data.stackMaxCount;
        other.count = total - count;
    }
    
    public bool avaibleFor(Item other) => Empty || (data == other.data && !Full);

    public ItemData Data => data;
    public bool Full => data && count >= data.stackMaxCount;
    public bool Empty => count == 0 || data == null;
    
    public int Count => count;

    public void CountLess1()
    {
        this.count--;
    }

}

