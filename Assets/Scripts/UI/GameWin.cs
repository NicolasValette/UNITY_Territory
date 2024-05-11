using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Territory.UI
{
    
    public class GameWin : MonoBehaviour
    {
        [SerializeField]
        private GameObject _winGameObject;
        [SerializeField]
        private TMP_Text _winText;
        [SerializeField]
        private float _waitingTime = 1.5f;

        // Start is called before the first frame update
        void Start()
        {
            _winGameObject.SetActive(false);
        }

        public void WinGame(int winnerID)
        {
            StartCoroutine(Wait(winnerID));
        }
        public IEnumerator Wait (int winnerID)
        {
            yield return new WaitForSeconds(_waitingTime);
            _winGameObject.SetActive(true);
            _winText.text = $"Player #{winnerID} wins !";
        }


    }
}
