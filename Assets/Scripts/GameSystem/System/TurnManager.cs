using System.Collections;
using System.Collections.Generic;
using Territory.GameSystem.PlayableCharacter;
using Territory.System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Territory.GameSystem
{
    public class TurnManager : MonoBehaviour
    {
  

        [SerializeField]
        private PlayersHandler _playersHandler;
        [SerializeField]
        private TMP_Text _playerText;

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

        public void NewTurn()
        {
            Character activePlayer = GetNextPlayer();
            _playerText.text = _currentPlayerIndex.ToString();
            activePlayer.Play();
            // send event ?
        }

    }
}
