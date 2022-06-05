using UnityEngine;
using System;
using System.Collections;


namespace Game {
    public  class Enemy : Character {
        [SerializeField]
        protected HealthBar _healthBar;

        [SerializeField]
        protected EnemyWeapon _weapon;

        [SerializeField]
        protected Collider2D _collider;

        [SerializeField]
        private Unit _unit;

        public event Action<bool> OnEnemySetMovingState;
        public event Action<Action> OnEnemyDeath;
        public event Action OnEnemyDestroy;
        public event Action<bool, Action<bool>, bool> OnEnemySpawn;
        public event Action<int, Action<bool>, bool> OnEnemyAttack;

        public void SetMovingState(bool movingState) {
            Debug.Log("SetState" + movingState);
            _unit.SetMovingState(movingState);
        }

        protected void InvokeAttackAnimation(int attackType) {
            OnEnemySetMovingState(false);
            OnEnemyAttack?.Invoke(attackType, OnEnemySetMovingState, true);
        }
        private void OnAttack() {
            InvokeAttackAnimation(0);
        }
        public void TakeDamage(int damage) {
            _currentHealth -= damage;

            _healthBar.SetHealth(_currentHealth);
            if (_currentHealth <= 0) {
                OnEnemyDeath?.Invoke(OnEnemyDestroy);
            }
        }

        private void Destroy() {
            Destroy(gameObject);
        }

        protected override void Start() {
            base.Start();
            _healthBar.SetMaxHealth(MaxHealth);
            if (_weapon != null) {
                _weapon.OnAttack += OnAttack;
            }
            OnEnemySetMovingState += SetMovingState;
            OnEnemyDestroy += Destroy;

            OnEnemySpawn?.Invoke(true, OnEnemySetMovingState, true);
        }     
    }
}
