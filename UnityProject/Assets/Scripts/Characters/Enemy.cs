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

        public event Action OnEnemyDeath;
        public event Action OnEnemySpawn;
        public event Action<int> OnEnemyAttack;

        
        protected void InvokeAttackAnimation(int attackType) {
            OnEnemyAttack?.Invoke(attackType);
        }

        public void TakeDamage(int damage) {
            _currentHealth -= damage;

            _healthBar.SetHealth(_currentHealth);
            if (_currentHealth <= 0) {
                OnEnemyDeath?.Invoke();
                Debug.Log("died");
                _weapon.enabled = false;
                _collider.enabled = false;
                StartCoroutine(DoDestroyInTime(5f));
            }
        }
        protected IEnumerator DoDestroyInTime(float time) {
            _healthBar.gameObject.SetActive(false);
            yield return new WaitForSeconds(time);
            Death();
        }

        protected void Death() {
            Destroy(gameObject);
        }

        protected override void Start() {
            base.Start();
            _healthBar.SetMaxHealth(MaxHealth);

            OnEnemySpawn?.Invoke();
        }     
    }
}
