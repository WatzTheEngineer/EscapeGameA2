using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    private LineRenderer _lineRenderer;

    public LineRenderer LineRenderer
    {
        get
        {
            if (_lineRenderer == null)
            {
                _lineRenderer = GetComponent<LineRenderer>();
            }
            return _lineRenderer;
        }
    }

    public Transform[] Points
    {
        get { return points; }
        set { points = value; }
    }

    public void Start()
    {
        LineRenderer.positionCount = Points.Length;
    }

    private void Update()
    {
        UpdateLineRendererPositions();
    }

    public void UpdateLineRendererPositions()
    {
        for (int i = 0; i < Points.Length; i++)
        {
            LineRenderer.SetPosition(i, Points[i].position);
        }
    }
}