using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory.Events
{
    [CreateAssetMenu(fileName = "New ParamEvent", menuName = "Event/Param")]
    public class ParamGameEvent : ScriptableObject
    {
        private List<ParamGameEventListener> _listeners = new List<ParamGameEventListener>();

        public void Subscribe(ParamGameEventListener listener)
        {
            _listeners.Add(listener);
        }
        public void Unsubscribe(ParamGameEventListener listener)
        {
            _listeners.Remove(listener);
        }
        public void Raise(GameObject item)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(item);
            }
        }
    }
}
