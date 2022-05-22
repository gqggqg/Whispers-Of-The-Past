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
<<<<<<< Updated upstream
        private Weapon _weapon;
=======
        private Enemy _enemy;
>>>>>>> Stashed changes


        private bool _facingRight;

<<<<<<< Updated upstream

        private void Start() {
            if (_movement != null) {
                _movement.OnMove += OnMove;
            }

            if (_weapon != null) {
                _weapon.OnShoot += OnShoot;
            }
=======
        void Start() {
            _movement.OnMove += OnMove;
            _playerAttack.OnAttack += OnAttack;
            _enemy.OnEnemyDeath += OnEnemyDeath;
        }

        private void OnEnemyDeath() {

>>>>>>> Stashed changes
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
