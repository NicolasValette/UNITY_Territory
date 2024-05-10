using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

namespace Territory.GameSystem.MouseSystem.States
{
    public class StateDrop : State
    {
        private bool _isMoveSucessfull = false;
        public StateDrop(MousePoint mouse) : base(mouse)
        {
        }

        public override void EnterState()
        {
            _isMoveSucessfull = false;
            Ray rayToMouse = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit2D raycastHit = Physics2D.Raycast(rayToMouse.origin, rayToMouse.direction);
            if (raycastHit.collider != null)
            {
                raycastHit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
              
                _isMoveSucessfull =  _mouse.MovHandler.TryMoveValue(new Pair<GameObject, GameObject>(_mouse.SelectedGameObject, raycastHit.collider.gameObject));
                Debug.Log("Move is " + _isMoveSucessfull);
                
              
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
            return (!_isMoveSucessfull) ? new StateIdle(_mouse) : new StateInactive(_mouse);
        }
    }
}