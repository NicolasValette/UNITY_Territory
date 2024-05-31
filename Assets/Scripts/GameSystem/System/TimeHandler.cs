using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Interfaces;
using Territory.GameSystem.Node;
using Territory.GameSystem.PlayableCharacter;
using Territory.Map;
using Territory.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Territory.GameSystem
{
    public class TimeHandler : MonoBehaviour
    {
        [SerializeField]
        private GameOptionsData _gameOption;
        [SerializeField]
        private float _gameTickDuration = 5f;
        [SerializeField]
        private float _AIReflexionTime = 0.75f;
        [SerializeField]
        private PlayersHandler _playersHandler;
        [SerializeField]
        private GraphManager _graph;
        [SerializeField]
        private UnityEvent OnGameStart;
        [SerializeField]
        private UnityEvent OnGameTick;
        [SerializeField]
        private UnityEvent<int> OnGameWin;

        [SerializeField]
        private UnityEvent<MovementOrder> OnValueMoved;
        private float _gameTimeSinceLastTick;
        private bool _timeIsOn;
        private bool _gameWin = false;
        // Start is called before the first frame update
        void Start()
        {
            _gameTimeSinceLastTick = 0f;
            _gameWin = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!_gameWin && _timeIsOn)
            {
                _gameTimeSinceLastTick += Time.deltaTime;
                if (_gameTimeSinceLastTick >= _gameTickDuration)
                {
                    for (int i = 0; i < _playersHandler.PlayersList.Count; i++)
                    {
                        if (_graph.GetListOfOwnedNode(i).Count <= 0)
                        {
                            _playersHandler.PlayersList[i].Eliminate();
                        }
                    }

                    List<int> winIDs = _playersHandler.GetIDsOfAlivePlayers();
                    if (winIDs.Count <= 1) 
                    {
                        StopAllCoroutines();
                        _gameWin = true;
                        OnGameWin.Invoke((winIDs.Count == 1) ? winIDs[0] : -1);
                    }

                    //event
                    OnGameTick.Invoke();
                    _gameTimeSinceLastTick = 0f;

                    
                }
            }
        }
        public void StartGameTime()
        {
            float timer = PlayerPrefs.GetFloat("AITimer", _AIReflexionTime);
            Debug.Log("Timer AI : " + timer);
            _gameTimeSinceLastTick = 0f;
            _timeIsOn = true;
            _gameWin = false;
            Debug.Log("Humain PLayer : " + _gameOption.NumberOfHumanPlayer + " AIPlayer : " + _gameOption.NumberOfAIPlayer);
            if (_gameOption.NumberOfAIPlayer + _gameOption.NumberOfHumanPlayer !=2)
            {
                Debug.Log("Default SETUP");
                _gameOption.NumberOfHumanPlayer = 1;
                _gameOption.NumberOfAIPlayer = 1;
            }
            _playersHandler.CreatePlayersList(_gameOption.NumberOfAIPlayer, _gameOption.NumberOfHumanPlayer);
            OnGameStart.Invoke();
            foreach (Character cpu in _playersHandler.PlayersList)
            {
                if (cpu is Computer)
                {
                    Debug.Log("Launch CPU #" + cpu.ID);
                    StartCoroutine(AITimer(cpu.ID, timer));
                }
            }
            
        }
        public IEnumerator AITimer(int idPlayer, float timer)
        {
            IBrain computer = _playersHandler.GetPlayerByID(idPlayer) as IBrain;
            while (!_playersHandler.GetPlayerByID(idPlayer).IsEliminated)
            {
                Pair <GameObject, GameObject> move = computer.GetNextMove(_graph.Graph);
                MovementOrder movementOrder = new MovementOrder(move.Value1, move.Value2, move.Value1.GetComponent<NodeElement>().Value);
                OnValueMoved.Invoke(movementOrder);
                yield return new WaitForSeconds(timer);
            }
        }
    }
}
