using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory.Datas
{
    [Serializable]
    public struct MovementOrder
    {
        public MovementOrder(GameObject road1, GameObject road2, int armyValue)
        {
            Road = new Pair<GameObject, GameObject> (road1, road2);
            ArmyValue = armyValue;
        }
        public Pair<GameObject, GameObject> Road;
        public int ArmyValue;
    }
}
