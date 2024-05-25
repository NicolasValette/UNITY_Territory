using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

namespace Territory.Datas
{
    [CreateAssetMenu(fileName ="New ArmySpriteData", menuName = "Datas/Create ArmySpriteData")]
    public class ArmySpriteData : ScriptableObject
    {
        [Tooltip("List of pair \"Color-Prefab\"")]
        [SerializeField]
        private List<Pair<PlayerColorEnum, GameObject>> _listArmy;

        public GameObject this[PlayerColorEnum key]
        {
            get
            {
                var t = _listArmy.DefaultIfEmpty(_listArmy[0]).FirstOrDefault((x => x.Value1 == key));
                return t.Value2;
            }
        }
            

    }
}
