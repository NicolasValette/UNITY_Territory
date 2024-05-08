using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Territory.GameSystem.Node
{

    public class NodeElement : MonoBehaviour
    {
        [SerializeField]
        private int _startingValue;
        [SerializeField]
        private TMP_Text _valueText;
        private NodeState _currentState;
        private Vector3 _startingScale;

        private int _value;
        public int Value { get { return _value; } }
        // Start is called before the first frame update
        void Start()
        {
            _value = _startingValue;
            _currentState = NodeState.Free;
            _valueText.text = _value.ToString();
            _startingScale = transform.localScale;
        }

        // Update is called once per frame
        void Update()
        {
       
        }

        public void AddValue(int value)
        {
            UpdateValue(_value + value);
        }
        public void UpdateValue(int value)
        {
            _value = value;
            _valueText.text = _value.ToString();
        }
        public void SelectNode()
        {
            _currentState = NodeState.Selected;
        }
        public void UnselectNode()
        {
            _currentState = NodeState.Free;
        }
        public void NodeIsValid()
        {
            _currentState = NodeState.Valid;
        }
        public void NodeIsNotValid()
        {
            _currentState = NodeState.Free;
        }

        private void OnMouseEnter()
        {
            if (_currentState == NodeState.Valid)
            {
                _startingScale = transform.localScale;
                transform.localScale += Vector3.one * 0.5f;
            }
        }
        private void OnMouseExit()
        {
            
                transform.localScale = _startingScale;
            
        }
    }
}
