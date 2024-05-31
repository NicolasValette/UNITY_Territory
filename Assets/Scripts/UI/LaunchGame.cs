using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory
{
    public class LaunchGame : MonoBehaviour
    {
        [SerializeField]
        private GameOptionsData _gameOptions;
        
        // Start is called before the first frame update
        void Start()
        {
            gameObject.SetActive(false);
        }

        public void SetOptionGame(int numberHumanPlayer)
        {
            _gameOptions.NumberOfHumanPlayer = numberHumanPlayer;
            _gameOptions.NumberOfAIPlayer = 2 - numberHumanPlayer;
        }
    }
}
