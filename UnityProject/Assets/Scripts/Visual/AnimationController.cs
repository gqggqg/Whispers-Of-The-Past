using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {

    public class AnimationController : MonoBehaviour {

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Movement _movement;

        [SerializeField]
        private Weapon _weapon;

        [SerializeField]
        private Enemy _enemy;

        private bool _facingRight;

        private void Start() {
            if (_movement != null) {
                _movement.OnMove += OnMove;
            }

            if (_weapon != null) {
                _weapon.OnShoot += OnShoot;
            }
            
            if (_enemy != null) {
                _enemy.OnEnemyDeath += OnEnemyDeath;
                _enemy.OnEnemySpawn += OnEnemySpawn;
            }
        }

        private void OnEnemySpawn() {
            StartCoroutine(PlayClipThenTransition("isSpawn", true));
        }
        private void OnEnemyDeath() {
            _animator.SetBool("isDead", true);
            StartCoroutine(PlayClip());
        }

        IEnumerator PlayClipThenTransition(string transitionParameter, bool transitionParameterValue) {
            Debug.Log("entry");
            yield return StartCoroutine(PlayClip());
            _animator.SetBool(transitionParameter, transitionParameterValue);
            Debug.Log("Set");
        }
        IEnumerator PlayClip() {
            var clipLength = _animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(clipLength);
            Debug.Log("Played");
        }

        private void OnShoot() {
            var dir = Input.mousePosition;
            dir = Camera.main.ScreenToWorldPoint(dir);
            dir = dir - transform.position;
            FlipToDirection(dir);
        }

        private void OnMove() {
            FlipToDirection(_movement.Direction);
            _animator.SetFloat("Speed", _movement.Speed);
        }
   
        private void FlipToDirection(Vector2 direction) {
            if (direction.x < 0 && !_facingRight || 
                direction.x > 0 && _facingRight ||     
                direction.x == 0) {
                return;
            }

            _facingRight = !_facingRight;
            _transform.Rotate(0f, 180f, 0f);
        }
    }
}
