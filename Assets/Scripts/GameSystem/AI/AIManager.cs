using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.AI.Core;
using Territory.Map;
using UnityEngine;

namespace Territory.GameSystem.AI
{
    public class AIManager : MonoBehaviour
    {
        [SerializeField]
        private GraphManager _graphManager;



        public GraphManager GraphMgr { get => _graphManager; }
        
        //public Pair<GameObject, GameObject> GetNextMove(int playerID)
        //{
        //    GameObject selectedNode = ChooseStartingNode(playerID);
        //    GameObject chosenNode = ChooseBestPlayFromStartingNode(playerID, selectedNode);
        //    return new Pair<GameObject, GameObject>(selectedNode, chosenNode);
        //}
        public AICore GetAICoreEasy (int playerID)
        {
            return new AIEasyCore(playerID, _graphManager);
        }
        public AICore GetAICoreMedium(int playerID)
        {
            return new AIMediumCore(playerID, _graphManager);
        }
    }
}
