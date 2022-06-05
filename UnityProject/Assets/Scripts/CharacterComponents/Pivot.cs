using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class Pivot : MonoBehaviour {
        [SerializeField]
        private GameObject _player;

        [SerializeField]
        private Flipper _flipper;


        private float eps = 0.1f;


        private void FixedUpdate() {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePosition - transform.position;

            _flipper.FlipToDirection(_player.transform, mousePosition - _player.transform.position);
            difference.z = 0;
            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, -rotationZ);

            //Debug.Log(difference);

            if (rotationZ > 0f && rotationZ < 180f) {

                if (_player.transform.eulerAngles.y < eps / 10) {
                    transform.localRotation = Quaternion.Euler(0, 180, rotationZ);
                    //Debug.Log(0);
                }
                else if (Mathf.Abs(_player.transform.eulerAngles.y - 180) < eps / 10) {
                    //Debug.Log(180);
                    transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
                }
            }
        }
        

    }
}

