using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawRoad : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private List<Transform> _roads;

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer.positionCount = _roads.Count;
    }

    // Update is called once per frame
    void Update()
    {
          
    }
    public void DrawLine()
    {
        List<Vector3> positions = _roads.Select(x => x.position).ToList();
        _lineRenderer.SetPositions(positions.ToArray());
    }
}
