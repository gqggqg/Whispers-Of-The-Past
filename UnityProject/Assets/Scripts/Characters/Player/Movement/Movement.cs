using UnityEngine;

namespace RPG {

    public class Movement : MonoBehaviour {
        [SerializeField]
        private Rigidbody2D _rb;

        [SerializeField]
        private Character _character;

        [SerializeField]
        private AnimationController _animationController;

        private Vector2 _direction;
        private float _playerSpeed;
        private bool _facingRight;
        private bool _isDirectionChange = false;
        public bool FacingRight => _facingRight;
        public float PlayerSpeed => _playerSpeed;

        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";


        private void Update() {
            var horizontal = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
            var vertical = Input.GetAxisRaw(VERTICAL_AXIS_NAME);

            _direction.Set(horizontal, vertical);
            _direction.Normalize();

            _isDirectionChange = _animationController.FlipToDirection(_direction);

            if (_isDirectionChange)
                _facingRight = !_facingRight;

            _playerSpeed = _direction.magnitude * _character.baseMovementSpeed;

            _animationController.UpdateAnimationState();
        }

        private void FixedUpdate() {
            var position = _rb.position + (_direction * _playerSpeed * Time.deltaTime);
            _rb.MovePosition(position);        
        }

    }
}
