using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.AI;
using UnityEngine;
using UnityEngine.Events;

namespace Territory.GameSystem.PlayableCharacter
{
    public class Computer : Character
    {

        [SerializeField]
        private UnityEvent OnNewEnnemyTurn;
        [SerializeField]
        private UnityEvent<Pair<GameObject, GameObject>> OnValueMoved;

        private AIManager _ai;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void InitPlayer(int ID, AIManager aiManager)
        {
            InitPlayer(ID);
            _ai = aiManager;
        }
        public override void Play()
        {
            if (_ai == null)
            {
                Debug.LogError("AI Component missing on Computer player");
            }
            OnNewEnnemyTurn.Invoke();

            Pair<GameObject, GameObject> chosenMove = _ai.GetNextMove(ID);
           
            StartCoroutine(Wait(_waitingTime, () =>
            {
                OnValueMoved.Invoke(chosenMove);
                Debug.Log("EndTurnCPU");
                OnEndTurn.Invoke();
            }));
        }
    }
}
