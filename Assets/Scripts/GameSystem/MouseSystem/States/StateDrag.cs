using System.Collections;
using System.Collections.Generic;
using Territory.GameSystem.Node;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Territory.GameSystem.MouseSystem.States
{
    public class StateDrag : State
    {
        private GameObject _objectToDrag;
        private bool _isBadSelection = false;

        private int _maxValue = 0;
        private int _midValue = 0;
        private TMP_Text _cursortText;
        public StateDrag(MousePoint mouse) : base(mouse)
        {
        }

        public override void EnterState()
        {
            NodeElement selectedNode = _mouse.SelectedGameObject.GetComponent<NodeElement>();
            if (selectedNode != null && selectedNode.OwnerID == _mouse.PlayerID)
            {

                // _mouse.SelectedGameObject.GetComponent<Renderer>().material.color = Color.red;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                mousePosition.z = 0;
                _objectToDrag = GameObject.Instantiate(_mouse.CirclePrefab, mousePosition, Quaternion.identity); ; ;
                Cursor.visible = false;
                _mouse.SelectNode(_mouse.SelectedGameObject);
                _maxValue = selectedNode.Value;
                _midValue = selectedNode.Value / 2;
                _cursortText = _objectToDrag.GetComponentInChildren<TMP_Text>();
            }
            else
            {
                _isBadSelection = true;
            }
        }

        public override void Execute()
        {
            if (!_isBadSelection)
            {

                //We get the mouse position and set Z coord to 0
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                mousePosition.z = 0;
                _objectToDrag.transform.position = mousePosition;
                if (Keyboard.current.ctrlKey.isPressed)
                {
                    _cursortText.text = _midValue.ToString();
                }
                else
                {
                    _cursortText.text = _maxValue.ToString();
                }
            }
        }

        public override void ExitState()
        {
            GameObject.Destroy(_objectToDrag);
            Cursor.visible = true;
        }

        public override State GetNextState()
        {
            if (_isBadSelection)
            {
                _mouse.BadSelection();
                return new StateIdle(_mouse);
            }
            return (!_mouse.IsSelected) ? new StateDrop(_mouse, _maxValue, _midValue) : null;
        }



    }
}