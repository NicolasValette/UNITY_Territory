using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Territory.GameSystem.PlayableCharacter
{
    public class Player : Character
    {
        [SerializeField]
        private UnityEvent OnNewPlayerTurn;
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
            Debug.Log("Player Turn");
            OnNewPlayerTurn.Invoke();
            StartCoroutine(Wait(_waitingTime));
        }
        public void EndTurn()
        {
            Debug.Log("End Player Turn");
            StartCoroutine(Wait(0.2f, OnEndTurn.Invoke));
        }
    }
}
