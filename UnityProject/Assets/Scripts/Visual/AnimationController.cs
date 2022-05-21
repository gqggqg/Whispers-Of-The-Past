using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class AnimationController : MonoBehaviour {
        // Start is called before the first frame update
        [SerializeField]
        private Animator _animator;

        private Transform position;
        private bool _facingRight;


        public void UpdateFloatParameter(string parameterName, float parameterValue) {
            _animator.SetFloat(parameterName, parameterValue);
        }
        public void FlipToDirection(Vector2 direction) {
            if (direction.x > 0 && _facingRight)
                return;
            if (direction.x < 0 && !_facingRight)
                return;
            if (direction.x == 0)
                return;

            transform.Rotate(0f, 180f, 0f);
            _facingRight = !_facingRight;
        }

        public void Flip() {
            transform.Rotate(0f, 180f, 0f);
            _facingRight = !_facingRight;
        }
    }
}