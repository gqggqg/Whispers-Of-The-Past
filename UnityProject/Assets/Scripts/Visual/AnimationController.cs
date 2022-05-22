using UnityEngine;

namespace RPG {

    public class AnimationController : MonoBehaviour {

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Movement _movement;

        [SerializeField]
        private Weapon _weapon;

        [SerializeField]
        private Enemy _enemy;



        private bool _facingRight;



        private void Start() {
            if (_movement != null) {
                _movement.OnMove += OnMove;
            }

            if (_weapon != null) {
                _weapon.OnShoot += OnShoot;
            }
            
            if (_enemy != null) {
                _enemy.OnEnemyDeath += OnEnemyDeath;
            }
        }

        private void OnEnemyDeath() {

        }

        private void OnShoot() {
            var dir = Input.mousePosition;
            dir = Camera.main.ScreenToWorldPoint(dir);
            dir = dir - transform.position;
            FlipToDirection(dir);
        }

        private void OnMove() {
            FlipToDirection(_movement.Direction);
            _animator.SetFloat("Speed", _movement.Speed);
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
