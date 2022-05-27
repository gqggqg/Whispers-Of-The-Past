using UnityEngine;
using System;

namespace Game {

    public class Movement : MonoBehaviour {

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private int _baseSpeed;

        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";


        private Vector2 _direction;
        public Vector2 Direction => _direction;

        private float _speed;
        public float Speed => _speed;


        public event Action OnMove;


        private void Update() {
            var horizontal = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
            var vertical = Input.GetAxisRaw(VERTICAL_AXIS_NAME);

            if (_direction.x == horizontal && _direction.y == vertical) {
                return;
            }

            _direction.Set(horizontal, vertical);
            _direction.Normalize();
            _speed = _direction.magnitude * _baseSpeed;

            OnMove?.Invoke();
        }

        private void FixedUpdate() {
            var position = _rigidbody.position + (_direction * _speed * Time.deltaTime);
            _rigidbody.MovePosition(position);      
        }
    }
}
