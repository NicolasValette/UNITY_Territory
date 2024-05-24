using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Territory.GameSystem.Node;
using TMPro;
using UnityEngine;
using UnityEngine.Splines;

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

        private GameObject _origin;
        private GameObject _target;

        private int _value;
        private int _ownerID;

        private SplineContainer _spline;
        private bool _isBackward;
        private bool _isMovementFinish;
        private void Start()
        {
            //EndingPosition = _position.position;
            //transform.rotation = Quaternion.LookRotation(EndingPosition - transform.position, transform.right);
            _isMovementFinish = false;
        }

        public void InitMove(GameObject origin, GameObject target, int value, int ownerID, SplineContainer spline, bool isBackward)
        {
            _origin = origin;
            _target = target;
            _value = value;
            _ownerID = ownerID;
            _isBackward = isBackward;
            _spline = spline;
        }

        public void StartMove()
        {
            _valueText.text = _value.ToString();
            if (_verbose) Debug.Log($"Moving {_value} from {transform.position} to {_target.transform.position}");

           
            StartCoroutine(Move());
        }

        //public void StartMove()
        //{
        //    _valueText.text = _value.ToString();
        //    if (_verbose) Debug.Log($"Moving {_value} from {transform.position} to {_target.transform.position}");

        //    NodeElement nodeElement = _target.GetComponent<NodeElement>();
        //    if (nodeElement != null)
        //    {
        //        nodeElement.ConquerNode(_value, _ownerID);

        //    }
        //    StartCoroutine(Move());
        //}
        private void EndMove()
        {
            NodeElement nodeElement = _target.GetComponent<NodeElement>();
            if (nodeElement != null)
            {
                nodeElement.ConquerNode(_value, _ownerID);

            }
            _target.GetComponent<NodeElement>().UpdateDisplay();
            Destroy(gameObject);
        }

        public IEnumerator Move()
        {

            if (_isBackward)
            {
                float timer = _duration;
                while (timer >= 0)
                {
                    _spline.Evaluate(timer, out Unity.Mathematics.float3 position, out Unity.Mathematics.float3 tangeant, out Unity.Mathematics.float3 up);
                    
                    transform.position = /*_spline.transform.position +*/ new Vector3(position.x, position.y, position.z);
                    timer -= Time.deltaTime;
                    yield return null;
                }
                transform.position = _spline.transform.position;
            }
            else
            {
                float timer = 0;
                while (timer < _duration)
                {
                    _spline.Evaluate(timer, out Unity.Mathematics.float3 position, out Unity.Mathematics.float3 tangeant, out Unity.Mathematics.float3 up);
                    transform.position = /*_spline.transform.position +*/ new Vector3(position.x, position.y, position.z);
                    timer += Time.deltaTime;
                    yield return null;
                }
                _spline.Evaluate(1, out Unity.Mathematics.float3 finalPosition, out Unity.Mathematics.float3 finalTangeant, out Unity.Mathematics.float3 finalUp);
                transform.position = /*_spline.transform.position +*/ new Vector3(finalPosition.x, finalPosition.y, finalPosition.z);
            }
            

            _isMovementFinish = true;
            EndMove();
            
        }
        //public IEnumerator Move()
        //{
        //    float time = 0;
        //    Vector3 startPosition = transform.position;

        //    while (time < _duration)
        //    {
        //        transform.position = Vector3.Lerp(startPosition, _target.transform.position, time / _duration);
        //        time += Time.deltaTime;
        //        yield return null;
        //    }
        //    transform.position = _target.transform.position;
        //    _isMovementFinish = true;
        //    _target.GetComponent<NodeElement>().UpdateDisplay();
        //    Destroy(gameObject);
        //}
    }
}
