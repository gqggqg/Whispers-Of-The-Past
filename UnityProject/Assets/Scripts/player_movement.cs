using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    private float _velocity;
    private Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _velocity = 0.3f;
        _direction = new Vector3(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            _direction.y = _direction.y + _velocity;
        }
        if (Input.GetKey(KeyCode.S)) {
            _direction.y = _direction.y - _velocity;
        }
        if (Input.GetKey(KeyCode.D)) {
            _direction.x = _direction.x + _velocity;
        }
        if (Input.GetKey(KeyCode.A)) {
            _direction.x = _direction.x - _velocity;
        }
        Vector3.Normalize(_direction);
        this.transform.position = this.transform.position + _direction;
    }
}
