using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _player_velocity;
    [SerializeField]
    private Vector3 _direction;

    void Start(){
    }

    void FixedUpdate(){
        _direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            _direction.y = _direction.y + _player_velocity;
        }
        if (Input.GetKey(KeyCode.S)) {
            _direction.y = _direction.y - _player_velocity;
        }
        if (Input.GetKey(KeyCode.D)) {
            _direction.x = _direction.x + _player_velocity;
        }
        if (Input.GetKey(KeyCode.A)) {
            _direction.x = _direction.x - _player_velocity;
        }
        _direction = Vector3.Normalize(_direction) * _player_velocity;
        this.transform.position = this.transform.position + _direction;
    }
}
