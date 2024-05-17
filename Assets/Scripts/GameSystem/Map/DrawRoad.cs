using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Territory.Datas;
using UnityEngine;

public class DrawRoad : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private List<Transform> _roads;
    [SerializeField]
    private GameObject _roadPrefab;

    private List<GameObject> _roadList;

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
    
    public void DrawGraph(Graph<GameObject> graph)
    {
        _roadList = new List<GameObject>();
        List<Pair<GameObject, GameObject>> edges = graph.GetUndirectedEdges();

        for (int i = 0; i < edges.Count; i++)
        {
            GameObject road = Instantiate(_roadPrefab, gameObject.transform);
            LineRenderer lr = road.GetComponent<LineRenderer>();
            lr.positionCount = 2;
            lr.SetPosition(0, edges[i].Value1.transform.position + (Vector3.forward * 0.1f));
            lr.SetPosition(1, edges[i].Value2.transform.position + (Vector3.forward * 0.1f));
            lr.startColor = Color.red;
            lr.endColor = Color.red;
            _roadList.Add(road);
            
            
        }
        
    }
    public void EraseAllRoad()
    {
        for (int i=0; i < _roadList.Count; i++)
        {
            Destroy(_roadList[i]);
        }
        _roadList.Clear();
    }
}
