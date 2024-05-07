using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
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

        public Graph<GameObject> GetGraph()
        { 
            return _graph;
        }
        public void DrawGraph()
        {
            _drawer.DrawGraph(_graph);
        }
    }
}
