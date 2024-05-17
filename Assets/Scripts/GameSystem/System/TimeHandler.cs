using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Interfaces;
using Territory.GameSystem.PlayableCharacter;
using Territory.Map;
using UnityEngine;
using UnityEngine.Events;

namespace Territory.GameSystem
{
    public class TimeHandler : MonoBehaviour
    {
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
        private UnityEvent<Pair<GameObject, GameObject>> OnValueMoved;
        private float _gameTimeSinceLastTick;
        private bool _timeIsOn;
        // Start is called before the first frame update
        void Start()
        {
            _gameTimeSinceLastTick = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (_timeIsOn)
            {
                _gameTimeSinceLastTick += Time.deltaTime;
                if (_gameTimeSinceLastTick >= _gameTickDuration)
                {
                    //event
                    Debug.Log("GrowthTick");
                    OnGameTick.Invoke();
                    _gameTimeSinceLastTick = 0f;
                }
            }
        }
        public void StartGameTime()
        {
            _gameTimeSinceLastTick = 0f;
            _timeIsOn = true;
            _playersHandler.CreatePlayersList(1, 1);
            OnGameStart.Invoke();
            StartCoroutine(AITimer(_playersHandler.PlayersList[1].ID, _AIReflexionTime));
        }
        public IEnumerator AITimer(int idPlayer, float timer)
        {
            IBrain computer = _playersHandler.GetPlayerByID(idPlayer) as IBrain;
            while (!_playersHandler.GetPlayerByID(idPlayer).IsEliminated)
            {
                Pair <GameObject, GameObject> move = computer.GetNextMove(_graph.Graph);
                Debug.Log("ID Played");
                OnValueMoved.Invoke(move);
                yield return new WaitForSeconds(timer);
            }
        }
    }
}
