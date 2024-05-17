using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.Map;
using UnityEngine;

namespace Territory.GameSystem.AI
{
    public class AIManager : MonoBehaviour
    {
        [SerializeField]
        private GraphManager _graphManager;

        private GameObject ChooseStartingNode(int playerID)
        {
            List<GameObject> ownedNode = _graphManager.GetListOfOwnedNodeWithValue(playerID);
            int selected =  Random.Range(0, ownedNode.Count);
            return ownedNode[selected];
        }
        private GameObject ChooseBestPlayFromStartingNode(int playerID, GameObject startingNode)
        {
            List<GameObject> neighbours = _graphManager.GetNeighboursOfNode(startingNode);
            int selected = Random.Range(0, neighbours.Count);
            return neighbours[selected];
        }
        public Pair<GameObject, GameObject> GetNextMove(int playerID)
        {
            GameObject selectedNode = ChooseStartingNode(playerID);
            GameObject chosenNode = ChooseBestPlayFromStartingNode(playerID, selectedNode);
            return new Pair<GameObject, GameObject>(selectedNode, chosenNode);
        }
    }
}
