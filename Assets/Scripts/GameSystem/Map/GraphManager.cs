using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
using UnityEngine;
using UnityEngine.Splines;

namespace Territory.Map
{
    public class GraphManager : MonoBehaviour
    {

        [SerializeField]
        private DrawRoad _drawer;
        [Header("List of roads")]
        [Tooltip("Describe all the roads of the map, each element in the list is a pair of node")]
        [SerializeField]
        private List<Triplet<GameObject, GameObject, SplineContainer>> _roads;

        private Graph<GameObject> _graph;
        private Dictionary<string, SplineContainer> _roadSpline;

        public Graph<GameObject> Graph { get => _graph; }

        // Start is called before the first frame update
        void Start()
        {

            BuildGraph();
            DrawGraph();

          
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void BuildGraph()
        {
            _graph = new Graph<GameObject>();
            _roadSpline = new Dictionary<string, SplineContainer>();
            //_graph.AddEdge(_gameObjects[0], _gameObjects[1]);
            //_graph.AddEdge(_gameObjects[1], _gameObjects[2]);
            //_graph.AddEdge(_gameObjects[1], _gameObjects[3]);
            //_graph.AddEdge(_gameObjects[3], _gameObjects[4]);
            //_graph.AddEdge(_gameObjects[4], _gameObjects[5]);
            for (int i = 0; i < _roads.Count; i++)
            {
                _graph.AddEdge(_roads[i].Value1, _roads[i].Value2);
                string key = _roads[i].Value1.GetInstanceID().ToString() + _roads[i].Value2.GetInstanceID();
                _roadSpline.Add(key, _roads[i].Value3);
            }
        }
        /// <summary>
        /// Get the spline of the road between starting and ending
        /// </summary>
        /// <param name="startingNode">Starting node of the road</param>
        /// <param name="endingNode">Ending node of the road</param>
        /// <param name="splineResult">the spline</param>
        /// <returns>Returns 1 if the road exists, -1 if the roads exists but backward, end 0 if the road doesn't exist</returns>
        public int GetSpline (GameObject startingNode, GameObject endingNode, out SplineContainer splineResult)
        {
            string key = startingNode.GetInstanceID().ToString() + endingNode.GetInstanceID();
            string reverseKey = endingNode.GetInstanceID().ToString() + startingNode.GetInstanceID();
            if (_roadSpline.ContainsKey(key))
            {
                splineResult = _roadSpline[key];
                return 1;
            }
            else if (_roadSpline.ContainsKey(reverseKey))
            {
                splineResult = _roadSpline[reverseKey];
                return -1;
            }
            else
            {
                splineResult = null;
                return 0;
            }
            
        }
        public List<GameObject> GetNeighboursOfNode(GameObject node)
        {
            return _graph.GetNeighbours(node);
        }
        public void DrawGraph()
        {
            _drawer.DrawGraph(_graph);
        }
        public void EraseGraphEdges()
        {
            _drawer.EraseAllRoad();
        }
        public List<GameObject> GetListOfOwnedNode(int playerId)
        {
            List<GameObject> ownedList = new List<GameObject>();
            List<GameObject> nodes = _graph.Nodes;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].GetComponent<NodeElement>().OwnerID == playerId)
                {
                    ownedList.Add(nodes[i]);
                }
            }
            return ownedList;
        }
        public List<GameObject> GetListOfOwnedNodeWithValue(int playerId)
        {
            List<GameObject> ownedList = new List<GameObject>();
            List<GameObject> nodes = _graph.Nodes;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].GetComponent<NodeElement>().OwnerID == playerId && nodes[i].GetComponent<NodeElement>().Value > 0)
                {
                    ownedList.Add(nodes[i]);
                }
            }
            return ownedList;
        }
        public int GetValueForPlayer(int playerID)
        {
            int value = 0;
            List<GameObject> ownedList = GetListOfOwnedNodeWithValue(playerID);
            for (int i = 0; i < ownedList.Count; i++)
            {
                value += ownedList[i].GetComponent<NodeElement>().Value;
            }
            return value;

        }
    }
}
