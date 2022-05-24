using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class AnimationController : MonoBehaviour {

        public Animator _animator;

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
                _enemy.OnEnemyAttack += OnEnemyAttack;
            }
        }

        private void OnEnemyAttack(int attackType) {

            _animator.SetBool("isPunch", true);
            StartCoroutine(PlayClipThenTransition("isPunch", false));

        }
        private void OnEnemySpawn() {
            Debug.Log("OnEnemySpawn");
            StartCoroutine(PlayClipThenTransition("isSpawn", true));
        }
        private void OnEnemyDeath() {
            _animator.SetBool("isDead", true);
            StartCoroutine(PlayClip());
        }

        IEnumerator PlayClipThenTransition(string transitionParameter, bool transitionParameterValue) {
            yield return StartCoroutine(PlayClip());
            _animator.SetBool(transitionParameter, transitionParameterValue);
            
        }
        IEnumerator PlayClip() {
            var clipLength = _animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(clipLength);
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
