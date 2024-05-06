using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using UnityEngine;

namespace Territory.Map
{
    [RequireComponent(typeof(GraphManager))]
    public class ShowValidNode : MonoBehaviour
    {
        
        Graph<GameObject> _graph = null;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void ChangeColorOfNeighbours (GameObject node, Color color)
        {
            if (_graph == null)
            {
                _graph = gameObject.GetComponent<GraphManager>().GetGraph();
            }

            List<GameObject> neighbours = _graph.GetNeighbours(node);
            for (int i = 0; i < neighbours.Count; i++)
            {
                neighbours[i].GetComponent<Renderer>().material.color = color;
            }
        }
        public void ShowValidNodeFromSelection(GameObject startingNode)
        {
            Debug.Log("Show");
            ChangeColorOfNeighbours(startingNode, Color.green);
        }
        public void HideValidNode(GameObject startingNode)
        {
            Debug.Log("Hide");
            ChangeColorOfNeighbours(startingNode, Color.white);
        }

    }
}
