using System.Collections;
using System.Collections.Generic;
using Territory.Animation;
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
        private int _growthValue = 1;
        [SerializeField]
        private TMP_Text _growthText;
        [SerializeField]
        private TMP_Text _valueText;
        private NodeState _currentState;
        private Vector3 _startingScale;
        public int Value { get => _value; }
        public int Growth { get => _growthValue; }
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
            _growthText.text = $"+{_growthValue}";
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
                GetComponentInChildren<PlayAnimationOnEvent>().IsActive = false;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ConquerNode (int value, int attackID)
        {

            if (_ownerID == attackID || _ownerID == -1)     // When we conquer free or move on owned node
            {
                AddValue(value);
                ChangeOwner(attackID);
            }
            else                                            // When we attack node
            {
                int newValue;
                if (value >= _value)    //attack succed
                {
                    newValue = value - _value;
                    ChangeOwner(attackID);
                }
                else // attack failed
                {
                    newValue = _value - value;
                }
                 UpdateValue(newValue);
            }
        }
        public void AddValue(int value)
        {
            UpdateValue(_value + value);
        }
        public void UpdateValue(int value)
        {
            _value = (value >= 0)?value:0;
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
            if (ID != -1)
            {
                GetComponentInChildren<PlayAnimationOnEvent>().IsActive = true;
            }
            _ownerID = ID;
        }
        public void UpdateDisplay()
        {
            _valueText.text = _value.ToString();
            if (_ownerID == 0)
            {
                _renderer.material.color = Color.blue;
            }
            else if (_ownerID == 1)
            {
                _renderer.material.color = Color.red;
            }
            else
            {
                _renderer.material.color = Color.white;
            }
        }
        public void GrowPopulation()
        {
            if (_ownerID != -1)
            {
                _value += _growthValue;
            }
            UpdateDisplay();
        }
        public void SetGrowth(int growth)
        {
            _growthValue = growth;
            _growthText.text = $"+{_growthValue}";
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
