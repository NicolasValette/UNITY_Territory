using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Territory.CameraControl
{

    public class MoveCamera : MonoBehaviour
    {

        [SerializeField]
        private Transform _cameraTransform;
        [SerializeField]
        private float _normalMovementSpeed;
        [SerializeField]
        private float _fastMovementSpeed;
        [SerializeField]
        private float _movementTime;

        
        private float _movementSpeed;
        private Vector3 _newPosition;
        private Vector2 _directionPressed;
        // Start is called before the first frame update
        void Start()
        {
            _newPosition = _cameraTransform.position;
            _directionPressed = Vector2.zero;
            _movementSpeed = _normalMovementSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            CameraMovement();
        }

        private void CameraMovement()
        {
            //if (Keyboard.current.aKey.isPressed|| Keyboard.current.leftArrowKey.isPressed)
            //{
            //    _newPosition += -_cameraTransform.right * _movementSpeed;
            //}
            //if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            //{
            //    _newPosition += _cameraTransform.right * _movementSpeed;
            //}
            //if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            //{
            //    _newPosition += _cameraTransform.up * _movementSpeed;
            //}
            //if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            //{
            //    _newPosition += -_cameraTransform.up * _movementSpeed;
            //}
            if (_directionPressed.x != 0)
            {
                _newPosition += _directionPressed.normalized.x * _cameraTransform.right * _movementSpeed;
            }
          
            if (_directionPressed.y != 0)
            {
                _newPosition += _directionPressed.normalized.y * _cameraTransform.up * _movementSpeed;
            }
            

            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _newPosition, Time.deltaTime * _movementTime);
        }

        public void OnMove(InputValue value)
        {
            _directionPressed = value.Get<Vector2>();
        }
        public void OnShiftPressed(InputValue value)
        {
            _movementSpeed = (value.isPressed) ? _fastMovementSpeed : _normalMovementSpeed;
        }

    }

}
