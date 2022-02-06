using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _player_velocity;
    private Vector3 _direction = new Vector3(0.0f, 0.0f);
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
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
        Vector3.Normalize(_direction);
        this.transform.position = this.transform.position + _direction;
    }
}
