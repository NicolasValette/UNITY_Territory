using System;
using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using UnityEngine;

namespace Territory
{
    [Serializable]
    [CreateAssetMenu(menuName = "Datas/Create new Army Team Sprite Data")]
    public class ArmyTeamSpriteData : ScriptableObject
    {
        [SerializeField]
        private PlayerColorEnum _teamColor;
        [SerializeField]
        private Sprite _manorSprite;
        [SerializeField]
        private Sprite _castleSprite;
        [SerializeField]
        private Sprite _ribbonSprite;
        [SerializeField]
        private GameObject _armyMoverPrefab;

        public PlayerColorEnum TeamColor { get => _teamColor; }
        public Sprite ManorSprite { get => _manorSprite; }
        public Sprite CastleSprite { get => _castleSprite; }
        public Sprite RibbonSPrite { get => _ribbonSprite; }
        public GameObject ArmyMoverPrefab { get  => _armyMoverPrefab; }
    }
}
