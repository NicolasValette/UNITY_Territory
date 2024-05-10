using System.Collections;
using System.Collections.Generic;
using Territory.GameSystem.AI;
using Territory.GameSystem.PlayableCharacter;
using UnityEngine;

namespace Territory.System
{
    public class PlayersHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;
        [SerializeField]
        private GameObject _computerPrefab;
        [SerializeField]
        private AIManager _AImanager;
        
        public List<Character> PlayersList { get; private set; }

        private List<GameObject> PlayerGOList;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void CreatePlayersList(int nbComputerPlayer, int nbHumanPlayer = 1)
        {
            PlayerGOList = new List<GameObject>();
            PlayersList = new List<Character>();
            int playerID = 0;
            //We add human player
            for (int i = 0; i < nbHumanPlayer; i++)
            {
                GameObject player = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
                PlayerGOList.Add(player);
                player.GetComponent<Character>().InitPlayer(playerID);
                playerID++;
                PlayersList.Add(player.GetComponent<Character>());
            }
            //We add Computer player
            for (int i = 0; i < nbComputerPlayer; i++)
            {
                GameObject player = Instantiate(_computerPrefab, Vector3.zero, Quaternion.identity);
                player.GetComponent<Computer>().InitPlayer(playerID, _AImanager);
                playerID++;
                PlayerGOList.Add(player);
                PlayersList.Add(player.GetComponent<Character>());
            }
        }
        
    }
}
