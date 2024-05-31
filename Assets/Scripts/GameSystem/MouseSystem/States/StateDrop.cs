using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

namespace Territory.GameSystem.MouseSystem.States
{
    public class StateDrop : State
    {
        private bool _isMoveSucessfull = false;
        private int _midValue;
        private int _maxValue;
        public StateDrop(MousePoint mouse, int maxValue=0, int midValue = 0) : base(mouse)
        {
            _midValue = midValue;
            _maxValue = maxValue;
        }

        public override void EnterState()
        {
            _isMoveSucessfull = false;
            Ray rayToMouse = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit2D raycastHit = Physics2D.Raycast(rayToMouse.origin, rayToMouse.direction);
            if (raycastHit.collider != null)
            {
                int armyValue = Keyboard.current.ctrlKey.isPressed ? _midValue:_maxValue;
                MovementOrder movementOrder = new MovementOrder(_mouse.SelectedGameObject, raycastHit.collider.gameObject, armyValue);
                _isMoveSucessfull =  _mouse.MovHandler.TryMoveValue(movementOrder);
                 
            }
            _mouse.UnselectNode();
        }

        public override void Execute()
        {
            
        }

        public override void ExitState()
        {
            _mouse.DeactivatePointer();
            if (_isMoveSucessfull )
            {
                _mouse.EndMovement();   
            }
        }

        public override State GetNextState()
        {
            //return (!_isMoveSucessfull) ? new StateIdle(_mouse) : new StateInactive(_mouse);
            return new StateIdle(_mouse);
        }
    }
}