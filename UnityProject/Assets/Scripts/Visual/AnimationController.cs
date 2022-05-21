using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class AnimationController : MonoBehaviour {
        // Start is called before the first frame update
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Movement _pMove;

        private Transform position;

        public void UpdateAnimationState() {

            _animator.SetFloat("Speed", _pMove.PlayerSpeed);
        }
        public bool FlipToDirection(Vector2 direction) {
            if (direction.x > 0 && _pMove.FacingRight)
                return false;
            if (direction.x < 0 && !_pMove.FacingRight)
                return false;
            if (direction.x == 0)
                return false;

            transform.Rotate(0f, 180f, 0f);
            return true;
        }

        public bool Flip() {
            transform.Rotate(0f, 180f, 0f);
            return true;
        }
    }
}