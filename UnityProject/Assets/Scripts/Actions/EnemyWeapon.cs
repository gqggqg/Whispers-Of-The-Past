using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Game {
    public abstract class EnemyWeapon : MonoBehaviour {
        [SerializeField]
        protected Enemy _wielder;



        [SerializeField]
        protected float _attackDelay;

        [SerializeField]
        protected float _attackCooldawn;

        [SerializeField]
        protected Collider2D _attackArea;



        public event Action OnAttack;

        protected Player _target = null;
        protected bool _isPlayerInRange = false;
        protected float _nextAttackTime = 0f;
        protected float _nextAttackAnimation = 0f;

        public bool IsPlayerInRange => _isPlayerInRange;

        public void OnTriggerEnter2D(Collider2D collision) {

            Player target = collision.GetComponent<Player>();
            if (target != null) {
                _isPlayerInRange = true;
                _target = target;
            }
        }

        public void OnTriggerExit2D(Collider2D collision) {
            Player target = collision.GetComponent<Player>();
            if (target != null) {
                _isPlayerInRange = false;
                _target = null;
            }
        }

        private void Update() {
            if (IsPlayerInRange == false) {
                if (Time.time >= _nextAttackAnimation) {
                    _nextAttackAnimation = Time.time;
                }
                if (Time.time >= _nextAttackTime) {
                    _nextAttackTime = _nextAttackAnimation + _attackDelay;
                }
                
                return;
            }

            if (Time.time >= _nextAttackAnimation) {
                OnAttack?.Invoke();
                _nextAttackAnimation = Time.time + _attackCooldawn + _attackDelay;
            }
            if (Time.time >= _nextAttackTime) {
                _nextAttackTime = _nextAttackAnimation + _attackDelay;
                if (IsPlayerInRange == true && _target != null) {
                    _target.TakeDamage(_wielder.BaseDamage);
                }
                
            }

        }

    }
}