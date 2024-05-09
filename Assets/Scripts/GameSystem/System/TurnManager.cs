using System.Collections;
using System.Collections.Generic;
using Territory.GameSystem.PlayableCharacter;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Territory.GameSystem
{
    public class TurnManager : MonoBehaviour
    {
  

        [SerializeField]
        private List<Character> _characterList;
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
            if(Keyboard.current.tKey.wasPressedThisFrame)
            {
                StartRound();
            }
        }

        public void StartRound()
        {
            _currentPlayerIndex = Random.Range(0, _characterList.Count);
            _playerText.text = _currentPlayerIndex.ToString();
            _characterList[_currentPlayerIndex].Play();
        }

        private Character GetNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _characterList.Count;
            return _characterList[_currentPlayerIndex];
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
