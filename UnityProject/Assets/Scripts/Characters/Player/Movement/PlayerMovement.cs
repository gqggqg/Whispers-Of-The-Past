using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class PlayerMovement : MonoBehaviour {

        private Player_Manager _player_manager;
        private Rigidbody2D _rbody;

        private float _player_speed;
        private Vector2 _direction;

        void Start() {
            _player_manager = GetComponent<Player_Manager>();
            _rbody = GetComponent<Rigidbody2D>();
            _player_speed = _player_manager.baseMovementSpeed * Time.deltaTime;
            _direction = Vector2.zero;
        }


        void Update() {
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");
            _direction.Normalize();
        }

        void FixedUpdate() {
            _rbody.MovePosition(_rbody.position + (_direction * _player_speed));        }
    }
}