using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
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

        private void ChangeColorOfNeighbours (GameObject node, Color color, bool isValid)
        {
            if (_graph == null)
            {
                _graph = gameObject.GetComponent<GraphManager>().Graph;
            }

            List<GameObject> neighbours = _graph.GetNeighbours(node);
            for (int i = 0; i < neighbours.Count; i++)
            {
                neighbours[i].GetComponent<Renderer>().material.color = color;
                if (isValid)
                {
                    neighbours[i].GetComponent<NodeElement>().NodeIsValid();
                }
                else
                {
                    neighbours[i].GetComponent<NodeElement>().NodeIsNotValid();
                }
            }
        }
        public void ShowValidNodeFromSelection(GameObject startingNode)
        {
            Debug.Log("Show");
            startingNode.GetComponent<NodeElement>().SelectNode();
            ChangeColorOfNeighbours(startingNode, Color.green, true);
        }
        public void HideValidNode(GameObject startingNode)
        {
            Debug.Log("Hide");
            startingNode.GetComponent<NodeElement>().UnselectNode();
            ChangeColorOfNeighbours(startingNode, Color.white, false);
        }

    }
}
