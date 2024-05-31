using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Territory.Datas
{
    [CreateAssetMenu(fileName ="New ArmySpriteData", menuName = "Datas/Create ArmySpriteData")]
    public class ArmySpriteData : ScriptableObject
    {
        [Tooltip("List of pair \"Color-Prefab\"")]
        [SerializeField]
        private List<Pair<PlayerColorEnum, ArmyTeamSpriteData>> _listArmy;

        public ArmyTeamSpriteData this[PlayerColorEnum key]
        {
            get
            {
                var t = _listArmy.DefaultIfEmpty(_listArmy[0]).FirstOrDefault((x => x.Value1 == key));
                return t.Value2;
            }
        }


    }
}
