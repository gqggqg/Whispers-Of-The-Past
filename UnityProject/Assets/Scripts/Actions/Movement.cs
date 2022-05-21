using UnityEngine;
using System;
namespace RPG {

    public class Movement : MonoBehaviour {
        [SerializeField]
        private Rigidbody2D _rb;

        [SerializeField]
        private Character _character;


        private Vector2 _direction;
        private float _playerSpeed;

        public event Action<Vector2, float> OnMove;
        public float PlayerSpeed => _playerSpeed;

        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";


        private void Update() {
            var horizontal = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
            var vertical = Input.GetAxisRaw(VERTICAL_AXIS_NAME);

            _direction.Set(horizontal, vertical);
            _direction.Normalize();

            //_animationController.FlipToDirection(_direction);

            _playerSpeed = _direction.magnitude * _character.baseMovementSpeed;

            OnMove?.Invoke(_direction, _playerSpeed);
        }

        private void FixedUpdate() {
            var position = _rb.position + (_direction * _playerSpeed * Time.deltaTime);
            _rb.MovePosition(position);        
        }

    }
}
