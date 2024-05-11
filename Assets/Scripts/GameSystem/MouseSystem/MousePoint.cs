using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.MouseSystem.States;
using Territory.GameSystem.Node;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Territory.GameSystem.MouseSystem
{
    public class MousePoint : MonoBehaviour
    {
        [SerializeField]
        private MovementHandler _movementHandler;
        [SerializeField]
        private GameObject _circlePrefab;
        [SerializeField]
        private UnityEvent<GameObject> OnSelection;
        [SerializeField]
        private UnityEvent<Pair<GameObject, GameObject>> OnValueMoved;
        [SerializeField]
        private UnityEvent<GameObject> OnUnselection;
        [SerializeField]
        private UnityEvent OnPlayerEndMovement;
        [SerializeField]
        private bool _debugMode;
        private State _currentState;

        public GameObject CirclePrefab { get => _circlePrefab; }
        public bool IsSelected { get; private set; }
        public bool IsActive { get; private set; } = false;
        public int PlayerID { get; private set; } = -1;
        public MovementHandler MovHandler { get => _movementHandler; }
        public GameObject SelectedGameObject { get; private set; }
        // Start is called before the first frame update
        void Start()
        {
            _currentState = new StateInactive(this);
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
            Debug.Log("click");
            if (_currentState is not StateInactive)
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
        }
        public void SelectNode(GameObject objectSelected)
        {
            OnSelection.Invoke(objectSelected);
        }
        public void UnselectNode()
        {
            OnUnselection.Invoke(SelectedGameObject);
        }
        public void EndMovement()
        {
            OnPlayerEndMovement.Invoke();
        }

        public void ActivatePointer()
        {
            IsActive = true;
        }
        public void StartPlayerTurn(int playerID)
        {
            Debug.Log("playerID : " + playerID);
            PlayerID = playerID;
        }
        public void DeactivatePointer()
        {
            IsActive = false;
        }
        public void BadSelection()
        {
            IsSelected = false;
        }
    }
}