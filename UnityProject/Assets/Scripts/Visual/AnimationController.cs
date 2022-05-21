using UnityEngine;

namespace RPG {

    [RequireComponent(typeof(Animator))]
    public class AnimationController : MonoBehaviour {

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Movement _movement;

        [SerializeField]
        private Weapon _weapon;


        private bool _facingRight;


        private void Start() {
            if (_movement != null) {
                _movement.OnMove += OnMove;
            }

            if (_weapon != null) {
                _weapon.OnShoot += OnShoot;
            }
        }

        private void OnShoot() {
            var dir = Input.mousePosition;
            dir = Camera.main.ScreenToWorldPoint(dir);
            dir = dir - transform.position;
            FlipToDirection(dir);
        }

        private void OnMove() {
            _animator.SetFloat("Speed", _movement.Speed);
            FlipToDirection(_movement.Direction);
        }
   
        private void FlipToDirection(Vector2 direction) {
            if (direction.x < 0 && !_facingRight || 
                direction.x > 0 && _facingRight ||     
                direction.x == 0) {
                return;
            }

            _facingRight = !_facingRight;
            _transform.Rotate(0f, 180f, 0f);
        }
    }
}
