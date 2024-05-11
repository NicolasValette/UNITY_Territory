using System.Collections;
using System.Collections.Generic;
using Territory.Map;
using TMPro;
using UnityEngine;

namespace Territory.UI
{
    public class DisplayArmyValues : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _player0txt;
        [SerializeField]
        private TMP_Text _player1txt;
        [SerializeField]
        private GraphManager _graphManager;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void UpdateValues()
        {
            _player0txt.text = $"Player #0 : {_graphManager.GetValueForPlayer(0)}";
            _player1txt.text = $"Player #1 : {_graphManager.GetValueForPlayer(1)}";
        }
    }
}
