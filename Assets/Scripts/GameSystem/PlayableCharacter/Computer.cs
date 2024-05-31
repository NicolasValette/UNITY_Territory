using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.AI;
using Territory.GameSystem.AI.Core;
using Territory.GameSystem.Interfaces;
using Territory.GameSystem.Node;
using Territory.Map;
using UnityEngine;
using UnityEngine.Events;

namespace Territory.GameSystem.PlayableCharacter
{
    public class Computer : Character, IBrain
    {

        [SerializeField]
        private UnityEvent OnNewEnnemyTurn;
        [SerializeField]
        private UnityEvent<MovementOrder> OnValueMoved;

        private GraphManager _graphManager;
        private AICore _ai;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void InitPlayer(int ID, AICore ai, GraphManager graph)
        {
            InitPlayer(ID);
            _ai = ai;
            _graphManager = graph;
        }
        public override void Play()
        {
            if (_ai == null)
            {
                Debug.LogError("AI Component missing on Computer player");
            }
            OnNewEnnemyTurn.Invoke();

            Pair<GameObject, GameObject> chosenMove = _ai.GetNextMove(_graphManager.Graph);
            MovementOrder movementOrder = new MovementOrder(chosenMove.Value1, chosenMove.Value2, chosenMove.Value1.GetComponent<NodeElement>().Value);
           
            StartCoroutine(Wait(_waitingTime, () =>
            {
                OnValueMoved.Invoke(movementOrder);
                OnEndTurn.Invoke();
            }));
        }

        public Pair<GameObject, GameObject> GetNextMove(Graph<GameObject> graph)
        {
            return _ai.GetNextMove(graph);
        }
    }
}
