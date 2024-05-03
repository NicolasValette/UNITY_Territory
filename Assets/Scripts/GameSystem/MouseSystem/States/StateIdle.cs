using System.Collections;
using System.Collections.Generic;
using Territory.GameSystem.MouseSystem;
using UnityEngine;

namespace Territory.GameSystem.MouseSystem.States
{
    public class StateIdle : State
    {
        public StateIdle(MousePoint mouse) : base(mouse)
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
            return _mouse.IsSelected ? new StateDrag(_mouse) : null;
        }
    }
}