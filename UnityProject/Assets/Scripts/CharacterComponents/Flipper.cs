using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class Flipper : MonoBehaviour {
        private bool _facingRight;
        public bool FacingRight => _facingRight;


        public void FlipToDirection(Transform _obj, Vector2 direction) {
            if (direction.x < 0 && !_facingRight ||
                direction.x > 0 && _facingRight) {
                return;
            }

            _facingRight = !_facingRight;
            _obj.Rotate(0, 180, 0);
        }
    }
}