using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Interfaces;
using Territory.Map;
using UnityEngine;

namespace Territory.GameSystem.AI.Core
{
    public abstract class AICore : IBrain
    {
        protected GraphManager _graphManager;
        protected int _index;

        public abstract Pair<GameObject, GameObject> GetNextMove(Graph<GameObject> graph);
        
    }
}
