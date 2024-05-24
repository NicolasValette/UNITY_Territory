using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
using Territory.Map;
using UnityEditor.Splines;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

namespace Territory
{
    public class MovementHandler : MonoBehaviour
    {

        [SerializeField]
        private GameObject _movementPrefab;
        [SerializeField]
        private GraphManager _graphManager;
        [SerializeField]
        private UnityEvent OnGraphUpdate;
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
                int direction = _graphManager.GetSpline(movementOrder.Road.Value1, movementOrder.Road.Value2, out SplineContainer splineResult);
                if (direction != 0)
                {
                    go.GetComponent<MoveValue>().InitMove(movementOrder.Road.Value1, movementOrder.Road.Value2, movementOrder.ArmyValue,
                        movementOrder.Road.Value1.GetComponent<NodeElement>().OwnerID, splineResult, (direction == -1) ? true : false);

                    go.GetComponent<MoveValue>().StartMove();
                    movementOrder.Road.Value1.GetComponent<NodeElement>().UpdateValue(movementOrder.Road.Value1.GetComponent<NodeElement>().Value - movementOrder.ArmyValue);
                    movementOrder.Road.Value1.GetComponent<NodeElement>().UpdateDisplay();
                    OnGraphUpdate.Invoke();
                }
            }

        }
        public bool TryMoveValue(MovementOrder movementOrder)
        {
            List<GameObject> neighbours = _graphManager.GetNeighboursOfNode(movementOrder.Road.Value1);
            if (neighbours.Contains(movementOrder.Road.Value2))
            {
                GameObject go = Instantiate(_movementPrefab, movementOrder.Road.Value1.transform.position, Quaternion.identity);
                int direction = _graphManager.GetSpline(movementOrder.Road.Value1, movementOrder.Road.Value2, out SplineContainer splineResult);
                if (direction != 0)
                {
                    go.GetComponent<MoveValue>().InitMove(movementOrder.Road.Value1, movementOrder.Road.Value2, movementOrder.ArmyValue,
                       movementOrder.Road.Value1.GetComponent<NodeElement>().OwnerID, splineResult, (direction == -1) ? true : false);


                    go.GetComponent<MoveValue>().StartMove();
                    movementOrder.Road.Value1.GetComponent<NodeElement>().UpdateValue(movementOrder.Road.Value1.GetComponent<NodeElement>().Value - movementOrder.ArmyValue);
                    movementOrder.Road.Value1.GetComponent<NodeElement>().UpdateDisplay();
                    OnGraphUpdate.Invoke();
                    return true;
                }
            }
            return false;

        }
    }
}
