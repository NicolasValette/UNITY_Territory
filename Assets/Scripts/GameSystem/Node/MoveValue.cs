using System.Collections;
using System.Collections.Generic;
using Territory.GameSystem.Node;
using TMPro;
using UnityEngine;

namespace Territory
{
    public class MoveValue : MonoBehaviour
    {
        [SerializeField]
        private bool _verbose = false;
        [SerializeField]
        private float _duration = 5f;
        [SerializeField]
        private TMP_Text _valueText;
        public GameObject Target { get; set; }

        public int Value { get; set; }
        public int Owner { get; set; }



        private bool _isMovementFinish;
        private void Start()
        {
            //EndingPosition = _position.position;
            //transform.rotation = Quaternion.LookRotation(EndingPosition - transform.position, transform.right);
            _isMovementFinish = false;
        }


        public void StartMove()
        {
            _valueText.text = Value.ToString();
            if (_verbose) Debug.Log($"Moving {Value} from {transform.position} to {Target.transform.position}");

            NodeElement nodeElement = Target.GetComponent<NodeElement>();
            if (nodeElement != null)
            {
                nodeElement.ConquerNode(Value, Owner);

            }
            StartCoroutine(Move());
        }

        public IEnumerator Move()
        {
            float time = 0;
            Vector3 startPosition = transform.position;

            while (time < _duration)
            {
                transform.position = Vector3.Lerp(startPosition, Target.transform.position, time / _duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = Target.transform.position;
            _isMovementFinish = true;
            Target.GetComponent<NodeElement>().UpdateDisplay();
            Destroy(gameObject);
        }
    }
}
