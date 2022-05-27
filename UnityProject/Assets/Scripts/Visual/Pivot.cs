using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;


    private bool _facingRight;
    private float eps = 0.1f;

    public bool FacingRight => _facingRight;

    private void FixedUpdate() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.z = 0;
        difference.Normalize();
        FlipToDirection(difference);

        float rotationZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -rotationZ);

        //Debug.Log(difference);

        if (rotationZ > 0f && rotationZ < 180f) {
            
            if (_player.transform.eulerAngles.y < eps/10) {
                transform.localRotation = Quaternion.Euler(0, 180, rotationZ);
                //Debug.Log(0);
            }
            else if (Mathf.Abs(_player.transform.eulerAngles.y - 180) < eps/10) {
                //Debug.Log(180);
                transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
            }
        }
    }
    private void FlipToDirection(Vector2 direction) {
        if (direction.x < 0 && !_facingRight ||
            direction.x > 0 && _facingRight ||
            Mathf.Abs(direction.x) < eps) {
            return;
        }

        _facingRight = !_facingRight;
        _player.transform.Rotate(0, 180, 0);
    }

}

