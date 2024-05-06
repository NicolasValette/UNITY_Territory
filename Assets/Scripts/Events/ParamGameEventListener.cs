using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Territory.Events
{
    public class ParamGameEventListener : MonoBehaviour
    {
        // Game event to lisen to
        [SerializeField]
        private ParamGameEvent _gameEvent;
        //Response when game event is raised
        [SerializeField]
        private UnityEvent<GameObject> _response;

        private void OnEnable()
        {
            _gameEvent.Subscribe(this);
        }
        private void OnDisable()
        {
            _gameEvent.Unsubscribe(this);
        }
        public void OnEventRaised(GameObject item)
        {
            _response.Invoke(item);
        }
    }
}
