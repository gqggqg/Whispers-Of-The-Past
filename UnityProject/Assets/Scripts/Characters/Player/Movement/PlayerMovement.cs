using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class PlayerMovement : MonoBehaviour {

        private Player_Manager _player_manager;


        private float _player_speed;
        private Vector2 _direction;
        [SerializeField]
        public bool _facingRight;

        void Start() {
            _player_manager = GetComponent<Player_Manager>();
            _direction = Vector2.zero;
            _facingRight = false;
        }


        void Update() {
            _direction.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _direction.Normalize();

            _player_speed = _direction.magnitude * _player_manager.baseMovementSpeed;

            if (_direction.x < 0 && _facingRight) {
                Flip();
            } 
            else if (_direction.x > 0 && !_facingRight) {
                Flip();
            }
            
            _player_manager.characterAnimator.SetFloat("Speed", _player_speed);
        }

        void FixedUpdate() {
            _player_manager.characterRb.MovePosition(_player_manager.characterRb.position + (_direction * _player_speed * Time.deltaTime));        
        }

        public void Flip() {
            _facingRight = !_facingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }
}