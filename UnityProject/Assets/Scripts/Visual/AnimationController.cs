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

        private void OnShoot() {
            _weapon._animator.Play(0);
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


        private void OnMove() {
            _animator.SetFloat("Speed", _movement.Speed);
        }
    }
}
