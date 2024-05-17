using System;
using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Territory.GameSystem.PlayableCharacter
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent OnEndTurn;
        [SerializeField]
        protected float _waitingTime;
        public abstract void Play();

        private int _playerID;
        public bool IsEliminated { get;private set; }

        public int ID { get => _playerID; protected set { _playerID = value;} }

        public void InitPlayer(int playerID)
        {
            _playerID = playerID;
            IsEliminated = false;
        }
        public void Eliminate()
        {
            Debug.Log("Player ID " + _playerID + " eliminated");
            IsEliminated = true;
        }

        public IEnumerator Wait(float waitingTime, Action action = null)
        {
            yield return new WaitForSeconds(waitingTime);
            if (action != null)
            {
                action();   
            }
        }

     
    }
}
