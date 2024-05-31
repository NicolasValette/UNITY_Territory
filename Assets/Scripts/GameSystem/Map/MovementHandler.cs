using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
using Territory.Map;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

namespace Territory
{
    public class MovementHandler : MonoBehaviour
    {
        [SerializeField]
        private GraphManager _graphManager;
        [SerializeField]
        private UnityEvent OnGraphUpdate;
        [SerializeField]
        private ArmySpriteData _armySpriteData;
  

        public void MoveValue(MovementOrder movementOrder)
        {
            TryMoveValue(movementOrder);
        }
        public bool TryMoveValue(MovementOrder movementOrder)
        {
            List<GameObject> neighbours = _graphManager.GetNeighboursOfNode(movementOrder.Road.Value1);
            if (neighbours.Contains(movementOrder.Road.Value2))
            {
                GameObject prefab = (movementOrder.Road.Value1.GetComponent<NodeElement>().OwnerID == 0) ? _armySpriteData[PlayerColorEnum.Blue].ArmyMoverPrefab : _armySpriteData[PlayerColorEnum.Red].ArmyMoverPrefab;
                GameObject go = Instantiate(prefab, movementOrder.Road.Value1.transform.position, Quaternion.identity);
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
