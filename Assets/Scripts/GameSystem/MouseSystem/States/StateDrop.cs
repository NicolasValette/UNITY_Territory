using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Territory.GameSystem.MouseSystem.States
{
    public class StateDrop : State
    {
        public StateDrop(MousePoint mouse) : base(mouse)
        {
        }

        public override void EnterState()
        {
            Ray rayToMouse = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit2D raycastHit = Physics2D.Raycast(rayToMouse.origin, rayToMouse.direction);
            if (raycastHit.collider != null)
            {
                raycastHit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            _mouse.UnselectNode();
        }

        public override void Execute()
        {
            
        }

        public override void ExitState()
        {
            
        }

        public override State GetNextState()
        {
            return new StateIdle(_mouse);
        }
    }
}