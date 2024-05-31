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
        UnityEvent OnEndTurn;
        // Start is called before the first frame update
        void Start()
        {
            
        }

       
        public void Skip()
        {
            OnEndTurn.Invoke();
        }
    }
}
