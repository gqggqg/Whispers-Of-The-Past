using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class Movement : MonoBehaviour {
        [SerializeField]
        public Animator animator;
        [SerializeField]
        public Rigidbody2D rb;
        [SerializeField]
        public Character character;

        private float _player_speed;
        private Vector2 _direction;
        [SerializeField]
        public bool _facingRight;

        void Start() {
            _direction = Vector2.zero;
            _facingRight = false;
        }


        void Update() {
            _direction.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _direction.Normalize();

            _player_speed = _direction.magnitude * character.baseMovementSpeed;

            if (_direction.x < 0 && _facingRight) {
                Flip();
            } 
            else if (_direction.x > 0 && !_facingRight) {
                Flip();
            }
            
            animator.SetFloat("Speed", _player_speed);
        }

        void FixedUpdate() {
            rb.MovePosition(rb.position + (_direction * _player_speed * Time.deltaTime));        
        }

        public void Flip() {
            _facingRight = !_facingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }
}