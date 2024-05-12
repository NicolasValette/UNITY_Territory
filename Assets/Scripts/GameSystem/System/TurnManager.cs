using System.Collections;
using System.Collections.Generic;
using Territory.GameSystem.PlayableCharacter;
using Territory.Map;
using Territory.System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
        [SerializeField]
        private UnityEvent OnGrowth;

        private List<Character> _characterList = new List<Character>();

        private bool _growthTurn = false;
        private int _currentPlayerIndex;
        private int _currentPlayerID;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            

        }
        private void BuildCharacterList()
        {
            List<Character> tempList = new List<Character>(_playersHandler.PlayersList);
            while (tempList.Count > 0)
            {
                int charInd = Random.Range(0, tempList.Count);
                _characterList.Add(tempList[charInd]);
                tempList.RemoveAt(charInd);
            }
            _currentPlayerID = 0;
        }

        public void OldStartRound()
        {
            _playersHandler.CreatePlayersList(1, 1);
            BuildCharacterList();
            _currentPlayerIndex = Random.Range(0, _playersHandler.PlayersList.Count);
            _playerText.text = _currentPlayerIndex.ToString();
            _playersHandler.PlayersList[_currentPlayerIndex].Play();
        }
        public void StartRound()
        {
            _playersHandler.CreatePlayersList(1, 1);
            BuildCharacterList();

            _playerText.text = _characterList[_currentPlayerID].ID.ToString();

            _characterList[_currentPlayerID].Play();
        }

        private Character OldGetNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _playersHandler.PlayersList.Count;
            return _playersHandler.PlayersList[_currentPlayerIndex];
        }
       
        private bool OldIsGameFinished()
        {
            Character activePlayer = _playersHandler.PlayersList[_currentPlayerIndex];

            for (int i = 0; i < _playersHandler.PlayersList.Count; i++)
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
        private bool IsGameFinished()
        {
            Character activePlayer = _characterList[_currentPlayerID];

            for (int i = _characterList.Count -1; i >= 0; i--)
            {
                if (_graph.GetValueForPlayer(_characterList[i].ID) <= 0)
                {
                    _characterList[i].Eliminate();
                    _characterList.Remove(_characterList[i]);
                    if (_characterList.Count == 1)
                    {
                        GameWin(_characterList[0].ID);
                        return true;
                    }
                }
            }
            return false;
        }

        public void NewTurn()
        {
           
            if (_growthTurn || !IsGameFinished())
            {
                if (_growthTurn)
                {
                    _growthTurn = false;
                    _currentPlayerID = -1;
                }
                _currentPlayerID++;
                if (_currentPlayerID >= _characterList.Count)   //Tick game
                {
                    Debug.Log("Growth");
                    //GrowthEvent
                    _growthTurn = true;
                    OnGrowth.Invoke();
                }
                else
                {
                    _playerText.text = _characterList[_currentPlayerID].ID.ToString();
                    _characterList[_currentPlayerID].Play();
                }
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
