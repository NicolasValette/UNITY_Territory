using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Territory.GameSystem.PlayableCharacter
{
    public class Computer : Character
    {

        [SerializeField]
        private UnityEvent OnNewEnnemyTurn;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public override void Play()
        {
            Debug.Log("Computer turn");
            OnNewEnnemyTurn.Invoke();
            StartCoroutine(Wait(_waitingTime, OnEndTurn.Invoke));
        }
    }
}
