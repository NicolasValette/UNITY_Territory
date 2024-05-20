using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
using Territory.Map;
using UnityEngine;

namespace Territory
{
    public class MovementHandler : MonoBehaviour
    {

        [SerializeField]
        private GameObject _movementPrefab;
        [SerializeField]
        private GraphManager _graphManager;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void MoveValue(MovementOrder movementOrder)
        {
            List<GameObject> neighbours = _graphManager.GetNeighboursOfNode(movementOrder.Road.Value1);
            if (neighbours.Contains(movementOrder.Road.Value2))
            {
                GameObject go = Instantiate(_movementPrefab, movementOrder.Road.Value1.transform.position, Quaternion.identity);
                go.GetComponent<MoveValue>().Target = movementOrder.Road.Value2;
                go.GetComponent<MoveValue>().Value = movementOrder.ArmyValue;
                go.GetComponent<MoveValue>().Owner = movementOrder.Road.Value1.GetComponent<NodeElement>().OwnerID;
                go.GetComponent<MoveValue>().StartMove();
                movementOrder.Road.Value1.GetComponent<NodeElement>().UpdateValue(movementOrder.Road.Value1.GetComponent<NodeElement>().Value - movementOrder.ArmyValue);
                movementOrder.Road.Value1.GetComponent<NodeElement>().UpdateDisplay();
            }


        }
        public bool TryMoveValue(MovementOrder movementOrder)
        {
            List<GameObject> neighbours = _graphManager.GetNeighboursOfNode(movementOrder.Road.Value1);
            if (neighbours.Contains(movementOrder.Road.Value2))
            {
                GameObject go = Instantiate(_movementPrefab, movementOrder.Road.Value1.transform.position, Quaternion.identity);
                go.GetComponent<MoveValue>().Target = movementOrder.Road.Value2;
                go.GetComponent<MoveValue>().Value = movementOrder.ArmyValue;
                go.GetComponent<MoveValue>().Owner = movementOrder.Road.Value1.GetComponent<NodeElement>().OwnerID;
                go.GetComponent<MoveValue>().StartMove();
                movementOrder.Road.Value1.GetComponent<NodeElement>().UpdateValue(movementOrder.Road.Value1.GetComponent<NodeElement>().Value - movementOrder.ArmyValue);
                movementOrder.Road.Value1.GetComponent<NodeElement>().UpdateDisplay();
                return true;
            }
            return false;

        }
    }
}
