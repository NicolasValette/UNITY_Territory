using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory.GameSystem.MouseSystem.States
{
    public abstract class State
    {
        protected MousePoint _mouse;

        public State(MousePoint mouse)
        {
            _mouse = mouse;
        }
        public abstract void EnterState();
        public abstract void Execute();
        public abstract void ExitState();
        public abstract State GetNextState();

        public override string ToString()
        {
            return this.GetType().Name;
        }

    }
}