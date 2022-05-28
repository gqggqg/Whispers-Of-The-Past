using UnityEngine;
using System.Collections;

namespace Game {

    public class Movement : MonoBehaviour {
        private Vector2 _direction;
        public Vector2 Direction => _direction;

        private float _curSpeed;
        private float _baseSpeed;
        public float BaseSpeed {
            get => _baseSpeed;
            set {
                _baseSpeed = value;
            }
        }

        public float CurSpeed => _curSpeed;

        
        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";


        public void ManualStopMove() {
            _curSpeed = 0f;
        }

        public void MoveToDirection(Vector2 direction) {
            _direction = direction;
            _direction.Normalize();
            _curSpeed = _direction.magnitude * _baseSpeed;
        }
        private void FixedUpdate() {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + _direction, _curSpeed * Time.deltaTime);
        }

    }
}
