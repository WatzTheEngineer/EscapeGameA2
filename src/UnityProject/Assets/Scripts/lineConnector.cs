using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform[] points;
    
    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        lineRenderer.positionCount = points.Length;
        
        for (int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        } 
    }
}
