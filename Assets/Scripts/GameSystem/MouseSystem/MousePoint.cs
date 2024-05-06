using System.Collections;
using System.Collections.Generic;
using Territory.GameSystem.MouseSystem.States;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Territory.GameSystem.MouseSystem
{
    public class MousePoint : MonoBehaviour
    {
        [SerializeField]
        private GameObject _circlePrefab;
        [SerializeField]
        private UnityEvent<GameObject> OnSelection;
        [SerializeField]
        private UnityEvent<GameObject> OnUnselection;
        [SerializeField]
        private bool _debugMode;
        private State _currentState;

        public GameObject CirclePrefab { get => _circlePrefab; }
        public bool IsSelected { get; private set; }
        public GameObject SelectedGameObject { get; private set; }
        // Start is called before the first frame update
        void Start()
        {
            _currentState = new StateIdle(this);
        }

        // Update is called once per frame
        void Update()
        {
            _currentState.Execute();
            State _nextState = _currentState.GetNextState();
            if (_nextState != null)
            {
                Transition(_nextState);
            }
        }

        private void Transition(State nextState)
        {
            string prevState = _currentState.ToString();

            _currentState.ExitState();
            _currentState = nextState;
            _currentState.EnterState();

            string debugStr = $"### Change state from ({prevState}) to ({_currentState})";
            if (_debugMode) Debug.Log(debugStr);
        }

        public void OnClick(InputValue value)
        {
            if (value.isPressed)
            {
                Ray rayToMouse = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit2D raycastHit = Physics2D.Raycast(rayToMouse.origin, rayToMouse.direction);
                Debug.Log("ray");
                if (raycastHit.collider != null)
                {
                    IsSelected = true;
                    SelectedGameObject = raycastHit.collider.gameObject;
                }
            }
            else
            {
                IsSelected = false;
               // SelectedGameObject = null;
            }
        }
        public void SelectNode(GameObject objectSelected)
        {
            OnSelection.Invoke(objectSelected);
        }
        public void UnselectNode()
        {
            OnUnselection.Invoke(SelectedGameObject);
        }
    }
}