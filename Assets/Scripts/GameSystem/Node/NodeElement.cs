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
        [Tooltip("-1 for free")]
        [SerializeField]
        private int _startingOwner = -1;
        [SerializeField]
        private TMP_Text _valueText;
        private NodeState _currentState;
        private Vector3 _startingScale;
        public int Value { get => _value; }
        public int OwnerID { get => _ownerID; }

        private Renderer _renderer;
        
        private int _ownerID;
        private int _value;
        // Start is called before the first frame update
        void Start()
        {
            _ownerID = _startingOwner;
            _value = _startingValue;
            _currentState = NodeState.Free;
            _valueText.text = _value.ToString();
            _startingScale = transform.localScale;
            _renderer = GetComponent<Renderer>();
            if (_ownerID == 0)
            {
                _renderer.material.color = Color.blue;
            }
            else if (OwnerID == 1)
            {
                _renderer.material.color = Color.red;
            }
            else
            {
                _renderer.material.color = Color.white;
            }
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
        public void ChangeOwner (int ID)
        {
            _ownerID = ID;
            if (_ownerID == 0)
            {
                _renderer.material.color = Color.blue;
            }
            else if (OwnerID == 1)
            {
                _renderer.material.color = Color.red;
            }
            else
            {
                _renderer.material.color = Color.white;
            }
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
