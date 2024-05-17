using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Territory
{
    public class ArmyGrowth : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent OnEndTurn;
        [SerializeField]
        private float _waitingTime;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private IEnumerator Wait(Action action)
        {
            yield return new WaitForSeconds(_waitingTime);
            action();
        }

        public void Growth()
        {
            StartCoroutine(Wait(() => {
                Debug.Log("EndGrowth");
                OnEndTurn.Invoke();
                }));
        }
    }
}
