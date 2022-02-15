using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _playerVelocity;

    private Vector3 _direction;

    void Start(){
    }

    void FixedUpdate(){
        ButtonMovement();
    }

    public void ButtonMovement() {
        _direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            _direction.y = _direction.y + _playerVelocity;
        }
        if (Input.GetKey(KeyCode.S)) {
            _direction.y = _direction.y - _playerVelocity;
        }
        if (Input.GetKey(KeyCode.D)) {
            _direction.x = _direction.x + _playerVelocity;
        }
        if (Input.GetKey(KeyCode.A)) {
            _direction.x = _direction.x - _playerVelocity;
        }
        _direction = Vector3.Normalize(_direction) * _playerVelocity;
        this.transform.position = this.transform.position + _direction;
    }
}
