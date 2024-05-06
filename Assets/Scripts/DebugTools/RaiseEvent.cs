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
        [SerializeField]
        private UnityEvent<GameObject> OnEvent2;
        [SerializeField]
        private GameObject node;
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
            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                OnEvent2.Invoke(node);
            }
        }
    }
}