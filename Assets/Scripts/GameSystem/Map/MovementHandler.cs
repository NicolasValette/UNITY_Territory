using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using Territory.GameSystem.Node;
using UnityEngine;

namespace Territory
{
    public class MovementHandler : MonoBehaviour
    {

        [SerializeField]
        private GameObject _movementPrefab;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void MoveValue(Pair<GameObject, GameObject> movementOrder)
        {
            GameObject go = Instantiate(_movementPrefab, movementOrder.Value1.transform.position, Quaternion.identity);
            go.GetComponent<MoveValue>().Target = movementOrder.Value2;
            go.GetComponent<MoveValue>().Value = movementOrder.Value1.GetComponent<NodeElement>().Value;
            go.GetComponent<MoveValue>().StartMove();
            movementOrder.Value1.GetComponent<NodeElement>().UpdateValue(0);


        }
    }
}
