using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory.GameSystem.Node
{
    public class NodeElement : MonoBehaviour
    {
        
        private NodeState _currentState;
        // Start is called before the first frame update
        void Start()
        {
            _currentState = NodeState.Free;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
