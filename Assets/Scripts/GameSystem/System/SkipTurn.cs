using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Territory.GameSystem
{
    public class SkipTurn : MonoBehaviour
    {
        [SerializeField]
        private Button _skipButton;
        [SerializeField]
        UnityEvent OnEndTurn;
        // Start is called before the first frame update
        void Start()
        {
            _skipButton.gameObject.SetActive(false);
        }

        public void ShowButton()
        {
            _skipButton.gameObject.SetActive(true);
        }
        public void HideButton()
        {
            _skipButton.gameObject.SetActive(false);
        }
        public void Skip()
        {
            Debug.Log("Skip");
            OnEndTurn.Invoke();
        }
    }
}
