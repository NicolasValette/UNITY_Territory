using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
using Territory.Map;
using Unity.VisualScripting;
using UnityEngine;

namespace Territory.GameSystem.AI.Core
{
    public class AIMediumCore : AICore
    {
        
        public AIMediumCore(int id, GraphManager graph)
        {
            _index = id;
            _graphManager = graph;
        }

      


        private Pair<GameObject, GameObject> ChoosePlay()
        {
            List<Pair<GameObject, GameObject>> possiblePlays = new List<Pair<GameObject, GameObject>>();

            List<GameObject> ownedNode = _graphManager.GetListOfOwnedNode(_index);
            for (int i = 0; i < ownedNode.Count; i++)
            {
                NodeElement startingNode = ownedNode[i].GetComponent<NodeElement>();
                List<GameObject> neighbours = _graphManager.GetNeighboursOfNode(ownedNode[i]);
                for (int j = 0; j < neighbours.Count; j++)
                {
                    NodeElement node = neighbours[j].GetComponent<NodeElement>();

                    if ((node.OwnerID == -1)||
                        ((node.OwnerID == (_index + 1) % 2) && node.Value < startingNode.Value) ||
                        ((node.OwnerID == _index) && (node.Value < startingNode.Value)))
                    {
                        possiblePlays.Add(new Pair<GameObject, GameObject>(ownedNode[i], neighbours[j]));
                    }
                    
                }
            }

            int chosenPlays = Random.Range(0, possiblePlays.Count);
            return possiblePlays[chosenPlays];
        }




        public override Pair<GameObject, GameObject> GetNextMove(Graph<GameObject> graph)
        {
            return ChoosePlay();
        }
    }
}
