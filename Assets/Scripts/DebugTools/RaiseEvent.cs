using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Territory.DebugTools
{
    public class RaiseEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent OnEvent;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current.pKey.wasPressedThisFrame)
            {
                OnEvent.Invoke();
            }
        }
    }
}