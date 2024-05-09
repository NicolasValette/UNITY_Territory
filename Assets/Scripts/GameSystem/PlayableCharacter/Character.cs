using System;
using System.Collections;
using System.Collections.Generic;
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
