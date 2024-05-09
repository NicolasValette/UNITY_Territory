using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory.GameSystem.MouseSystem.States
{
    public class StateInactive : State
    {

        public StateInactive(MousePoint mouse) : base(mouse)
        {
        }
        public override void EnterState()
        {
            
        }

        public override void Execute()
        {
            
        }

        public override void ExitState()
        {
           
        }

        public override State GetNextState()
        {
            return _mouse.IsActive ? new StateIdle(_mouse) : null;
        }
    }
}
