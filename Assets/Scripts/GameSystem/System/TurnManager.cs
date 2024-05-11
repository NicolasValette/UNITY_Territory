using System.Collections;
using System.Collections.Generic;
using Territory.GameSystem.PlayableCharacter;
using Territory.Map;
using Territory.System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Territory.GameSystem
{
    public class TurnManager : MonoBehaviour
    {


        [SerializeField]
        private PlayersHandler _playersHandler;
        [SerializeField]
        private GraphManager _graph;
        [SerializeField]
        private TMP_Text _playerText;
        [SerializeField]
        private UnityEvent<int> OnGameWin;

        private int _currentPlayerIndex;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }



        public void StartRound()
        {
            _playersHandler.CreatePlayersList(1, 1);
            _currentPlayerIndex = Random.Range(0, _playersHandler.PlayersList.Count);
            _playerText.text = _currentPlayerIndex.ToString();
            _playersHandler.PlayersList[_currentPlayerIndex].Play();
        }

        private Character GetNextPlayer()
        {
            
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _playersHandler.PlayersList.Count;



            return _playersHandler.PlayersList[_currentPlayerIndex];
        }
        private bool IsGameFinished()
        {
            Character activePlayer = _playersHandler.PlayersList[_currentPlayerIndex];

            for (int i = 0; i< _playersHandler.PlayersList.Count; i++)
            {
                if (_graph.GetValueForPlayer(_playersHandler.PlayersList[i].ID) <= 0)
                {
                    _playersHandler.PlayersList[i].Eliminate();
                }
            }

            List<int> idsOfAlivePlayer = _playersHandler.GetIDsOfAlivePlayers();
            if (idsOfAlivePlayer.Count <= 1)
            {
                if (idsOfAlivePlayer.Count == 1)
                {
                    GameWin(idsOfAlivePlayer[0]);
                }
                return true;
            }
            return false;
        }

        public void NewTurn()
        {
            if (!IsGameFinished())
            {
                Character activePlayer;

                activePlayer = GetNextPlayer();
                while (activePlayer.IsEliminated)
                {
                    activePlayer = GetNextPlayer();
                }

                _playerText.text = _currentPlayerIndex.ToString();
                activePlayer.Play();
            }

        
        }
        public void GameWin(int winnerID = -1)
        {
            Debug.Log("Game win by id : " + winnerID);
            OnGameWin.Invoke(winnerID);
        }

        // send event ?



    }
}
