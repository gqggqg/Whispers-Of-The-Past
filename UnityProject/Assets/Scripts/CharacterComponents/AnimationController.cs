using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game {

    public class AnimationController : MonoBehaviour {

        public Animator _animator;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Enemy _enemy;

        [SerializeField]
        private Player _player;


        private void Start() {


            if (_player != null) {
                _player.OnMove += OnMove;
                _player.Weapon.OnShoot += OnShoot;
            }

            if (_enemy != null) {
                _enemy.OnEnemyDeath += OnEnemyDeath;
                _enemy.OnEnemySpawn += OnEnemySpawn;
                _enemy.OnEnemyAttack += OnEnemyAttack;
            }
        }

        private void OnShoot() {
            _player.Weapon._animator.Play(0);
        }
        private void OnEnemyAttack(int attackType, Action<bool> callback = null, bool callbackParameter = false) {
            _animator.SetBool("isPunch", true);
            StartCoroutine(PlayClipThenTransition("isPunch", false, callback, callbackParameter));

        }
        private void OnEnemySpawn(bool parameter, Action<bool> callback, bool callbackParameter) {
            StartCoroutine(PlayClipThenTransition("isSpawn", true, callback, callbackParameter));
        }
        private void OnEnemyDeath(Action callback) {
            _animator.SetBool("isDead", true);
            StartCoroutine(PlayClip(callback));
        }

        IEnumerator PlayClipThenTransition(string transitionParameter, bool transitionParameterValue, Action<bool> callback = null, bool callbackParameter = false) {
            yield return StartCoroutine(PlayClip());
            _animator.SetBool(transitionParameter, transitionParameterValue);
            if (callback != null) {
                callback?.Invoke(callbackParameter);
            }
            
        }
        IEnumerator PlayClip(Action callback = null) {
            var clipLength = _animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(clipLength);
            if (callback != null) {
                callback?.Invoke();
            }
        }


        private void OnMove() {
            _animator.SetFloat("Speed", _player.Movement.CurSpeed);
        }
    }
}
