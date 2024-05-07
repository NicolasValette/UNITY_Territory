using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Territory.Datas
{
    /// <summary>
    /// Generic class to represent Graph struct
    /// </summary>
    public class Graph<T>
    {
        private Dictionary<string, List<T>> _edges;
        private Dictionary<string, T> _nodes;



        public Graph() 
        {
            _edges = new Dictionary<string, List<T>>();
            _nodes = new Dictionary<string, T>();
        }

        public void AddEdge(T from, T to, bool verbose = false)
        {
            // We add the nodes if they are new
            if (!_nodes.ContainsKey(from.ToString()))
            {
                _nodes.Add(from.ToString(), from);
            }
            if (!_nodes.ContainsKey(to.ToString()))
            {
                _nodes.Add(to.ToString(), to);
            }

            //We add edges if they don't exist
            if (!_edges.ContainsKey(from.ToString()))
            {
                _edges[from.ToString()] = new List<T>();
         
            }
            if (verbose) Debug.Log($"node : {from.ToString()}, add child : {to.ToString()}");
            _edges[from.ToString()].Add(to);

            if (!_edges.ContainsKey(to.ToString()))
            {
                _edges[to.ToString()] = new List<T>();
         
            }
            if (verbose) Debug.Log($"node : {to.ToString()}, add child : {from.ToString()}");
            _edges[to.ToString()].Add(from);
        }

        public void RemoveNode(T nodeToRemove)
        {
            List<T> neighbours = _edges[nodeToRemove.ToString()].ToList();
            for (int i = 0; i < neighbours.Count; i++)
            {
                T neighbour = neighbours[i];
                _edges[neighbour.ToString()].Remove(nodeToRemove);
            }
            _nodes.Remove(nodeToRemove.ToString());
            _edges.Remove(nodeToRemove.ToString());
            
        }

        public T GetNodeFromLabel(string node)
        {
            return _nodes[node];
        }
        public List<T> GetNeighbours(T node)
        {
            return _edges[node.ToString()].ToList();
        }
        public void RemoveEdge(T node1, T node2, bool verbose = false)
        {
            _edges[node1.ToString()].Remove(node2);
            _edges[node2.ToString()].Remove(node1);
        }
        public string PrintEdges()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var edge in _edges)
            {
                stringBuilder.AppendLine($"Edge from {edge.Key} :");
                for (int i=0; i<edge.Value.Count; i++)
                {
                    stringBuilder.AppendLine($"=> {edge.Value[i]}");
                }
                stringBuilder.AppendLine("####");
            }
            return stringBuilder.ToString();
        }

        public List<Pair<T, T>> GetUndirectedEdges()
        {
            List<Pair<T, T >> result = new List<Pair<T, T>>();

            foreach (var edge in _edges)
            {
                for (int i = 0; i < edge.Value.Count; i++)
                {
                    if (!result.Contains(new Pair<T,T>(_nodes[edge.Key], edge.Value[i])) && !result.Contains(new Pair<T, T>(edge.Value[i], _nodes[edge.Key])))
                    {
                        result.Add(new Pair<T, T>(_nodes[edge.Key], edge.Value[i]));
                    }
                }
            }

            return result;
        }

    }
}