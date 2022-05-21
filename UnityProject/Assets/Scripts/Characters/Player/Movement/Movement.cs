using UnityEngine;

namespace RPG {

    public class Movement : MonoBehaviour {

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Rigidbody2D _rb;

        [SerializeField]
        private Character _character;


        private Vector2 _direction;
        private float _playerSpeed;
        private bool _facingRight;
        public bool FacingRight => _facingRight;


        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";


        private void Update() {
            var horizontal = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
            var vertical = Input.GetAxisRaw(VERTICAL_AXIS_NAME);

            _direction.Set(horizontal, vertical);
            _direction.Normalize();

            if ((_direction.x < 0 && _facingRight) || (_direction.x > 0 && !_facingRight)) {
                Flip();
            }

            _playerSpeed = _direction.magnitude * _character.baseMovementSpeed;
            _animator.SetFloat("Speed", _playerSpeed);
        }

        private void FixedUpdate() {
            var position = _rb.position + (_direction * _playerSpeed * Time.deltaTime);
            _rb.MovePosition(position);        
        }

        public void Flip() {
            _facingRight = !_facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
