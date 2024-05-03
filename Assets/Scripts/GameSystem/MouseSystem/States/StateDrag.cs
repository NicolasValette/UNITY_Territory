using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Territory.GameSystem.MouseSystem.States
{
    public class StateDrag : State
    {
        private GameObject _objectToDrag;
        public StateDrag(MousePoint mouse) : base(mouse)
        {
        }

        public override void EnterState()
        {
            _mouse.SelectedGameObject.GetComponent<Renderer>().material.color = Color.red;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = 0;
            _objectToDrag = GameObject.Instantiate(_mouse.CirclePrefab, mousePosition, Quaternion.identity); ;;
            Cursor.visible = false;
        }

        public override void Execute()
        {
            //We get the mouse position and set Z coord to 0
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = 0;
            _objectToDrag.transform.position = mousePosition;
        }

        public override void ExitState()
        {
            GameObject.Destroy(_objectToDrag);
            Cursor.visible = true;
        }

        public override State GetNextState()
        {
            return (!_mouse.IsSelected) ? new StateDrop(_mouse) : null;
        }

 
        
    }
}