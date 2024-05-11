using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
using UnityEngine;

namespace Territory.Map
{
    public class GraphManager : MonoBehaviour
    {

        [SerializeField]
        private DrawRoad _drawer;
        [Header("List of roads")]
        [Tooltip("Describe all the roads of the map, each element in the list is a pair of node")]
        [SerializeField]
        private List<Pair<GameObject, GameObject>> _roads;

        private Graph<GameObject> _graph;

        public Graph<GameObject> Graph { get => _graph;}

        // Start is called before the first frame update
        void Start()
        {
            
            _graph = new Graph<GameObject>();
            //_graph.AddEdge(_gameObjects[0], _gameObjects[1]);
            //_graph.AddEdge(_gameObjects[1], _gameObjects[2]);
            //_graph.AddEdge(_gameObjects[1], _gameObjects[3]);
            //_graph.AddEdge(_gameObjects[3], _gameObjects[4]);
            //_graph.AddEdge(_gameObjects[4], _gameObjects[5]);
            for (int i = 0;i < _roads.Count;i++)
            {
                _graph.AddEdge(_roads[i].Value1, _roads[i].Value2);
            }
            DrawGraph();

            //var a = (_gameObjects[1].transform.position - _gameObjects[0].transform.position).magnitude;
            
            //Debug.Log(a);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

       
        public List<GameObject> GetNeighboursOfNode(GameObject node)
        {
            return _graph.GetNeighbours(node);
        }
        public void DrawGraph()
        {
            _drawer.DrawGraph(_graph);
        }
        public List<GameObject> GetListOfOwnedNode(int playerId)
        {
            List<GameObject> ownedList = new List<GameObject>();
            List <GameObject> nodes =  _graph.Nodes;

            for (int i=0; i<nodes.Count;i++)
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
            for (int i = 0; i<ownedList.Count;i++)
            {
                value += ownedList[i].GetComponent<NodeElement>().Value;
            }
            return value;

        }
    }
}
