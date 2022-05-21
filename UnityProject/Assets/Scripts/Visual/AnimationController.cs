using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class AnimationController : MonoBehaviour {
        // Start is called before the first frame update
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private PlayerAttack _playerAttack;

        [SerializeField]
        private Movement _movement;


        private Transform position;
        private bool _facingRight;

        void Start() {
            _movement.OnMove += OnMove;
            _playerAttack.OnAttack += OnAttack;
        }

        private void OnAttack() {
            Vector3 dir = Input.mousePosition;
            dir = Camera.main.ScreenToWorldPoint(dir);
            dir = dir - transform.position;
            FlipToDirection(dir);
        }
        private void OnMove(Vector2 direction, float speed) {
            _animator.SetFloat("Speed", speed);
            FlipToDirection(direction);
        }
   
        public void FlipToDirection(Vector2 direction) {
            if (direction.x > 0 && _facingRight)
                return;
            if (direction.x < 0 && !_facingRight)
                return;
            if (direction.x == 0)
                return;

            transform.Rotate(0f, 180f, 0f);
            _facingRight = !_facingRight;
        }

        public void Flip() {
            transform.Rotate(0f, 180f, 0f);
            _facingRight = !_facingRight;
        }
    }
}