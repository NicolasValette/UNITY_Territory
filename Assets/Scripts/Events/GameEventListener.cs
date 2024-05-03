using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Territory.Events
{
    /// <summary>
    /// Game event listener class
    /// add this to a game object to listen to an specific event
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        // Game event to lisen to
        [SerializeField]
        private GameEvent _gameEvent;
        //Response when game event is raised
        [SerializeField]
        private UnityEvent _response;

        private void OnEnable()
        {
            _gameEvent.Subscribe(this);
        }
        private void OnDisable()
        {
            _gameEvent.Unsubscribe(this);
        }
        public void OnEventRaised()
        {
            _response.Invoke();
        }
    }
}