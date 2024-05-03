using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory.Events
{
    [CreateAssetMenu(fileName = "New Event", menuName ="Event")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> _listeners = new List<GameEventListener>();

        public void Subscribe (GameEventListener listener)
        {
            _listeners.Add(listener);
        }
        public void Unsubscribe (GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
        public void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }
    }
}