using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using UnityEngine;

namespace Territory.GameSystem.Interfaces
{
    public interface IBrain
    {
        Pair<GameObject, GameObject> GetNextMove(Graph<GameObject> graph);
    }
}
