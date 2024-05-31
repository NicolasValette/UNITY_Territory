using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.PlayableCharacter;
using Territory.Map;
using UnityEngine;

namespace Territory.GameSystem.AI.Core
{
    public class AIEasyCore : AICore
    {
        public AIEasyCore(int id, GraphManager graph) 
        {
            _index = id;
            _graphManager = graph;
        }

        private GameObject ChooseStartingNode()
        {
            List<GameObject> ownedNode = _graphManager.GetListOfOwnedNode(_index);
            int selected = Random.Range(0, ownedNode.Count);
            return ownedNode[selected];
        }
        private GameObject ChooseBestPlayFromStartingNode(GameObject startingNode)
        {
            List<GameObject> neighbours = _graphManager.GetNeighboursOfNode(startingNode);
            int selected = Random.Range(0, neighbours.Count);
            return neighbours[selected];
        }
       

        public override Pair<GameObject, GameObject> GetNextMove(Graph<GameObject> graph)
        {
            GameObject selectedNode = ChooseStartingNode();
            GameObject chosenNode = ChooseBestPlayFromStartingNode(selectedNode);
            return new Pair<GameObject, GameObject>(selectedNode, chosenNode);
        }
    }
}
