using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Territory.Datas;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DrawRoad : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private List<Transform> _roads;
    [SerializeField]
    private GameObject _linePrefab;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DrawLineRender()
    {
        List<Vector3> positions = _roads.Select(x => x.position).ToList();
        _lineRenderer.SetPositions(positions.ToArray());

    }
    private void DrawLine (Vector3 from, Vector3 to)
    {
        //Vector3 directionnalVector = to - from;
        //Vector3 position = new Vector3 ((from.x + to.y) / 2f, (from.y + to.z) / 2f, from.z);
        //float dist = directionnalVector.magnitude;
        //Mathf.Asin(())
        // GameObject line = Instantiate(_linePrefab, )
    }
    
    public void DrawGraph(Graph<GameObject> graph, GameObject startingNode)
    {

        var visited = new HashSet<string>();
        var queue = new Queue<GameObject>();
        queue.Enqueue(startingNode);
        int index = 0;
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (!visited.Add(current.ToString()))
            {
                continue;
            }
            _lineRenderer.positionCount = index + 1;
            _lineRenderer.SetPosition(index, current.transform.position);
            index++;

            
            foreach (var connection in graph.GetNeighbours(current))
            {
                queue.Enqueue(connection);
                _lineRenderer.positionCount = index + 1;
                _lineRenderer.SetPosition(index, connection.transform.position);
                index++;
               
                _lineRenderer.positionCount = index + 1;
                _lineRenderer.SetPosition(index, current.transform.position);
                index++;
            }
        }
        
    }
}
