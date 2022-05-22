using UnityEngine;
using System;
using System.Collections;


namespace RPG {
    public class Enemy : Character {
        [SerializeField]
        public HealthBar _healthBar;

        public event Action OnEnemyDeath;
        public event Action OnEnemySpawn;
        public void TakeDamage(int damage) {
            _currentHealth -= damage;

            _healthBar.SetHealth(MaxHealth - _currentHealth);
            if (_currentHealth <= 0) {
                OnEnemyDeath?.Invoke();
                StartCoroutine(DoDestroyInTime(5f));
            }
        }
        private IEnumerator DoDestroyInTime(float time) {
            _healthBar.gameObject.SetActive(false);
            yield return new WaitForSeconds(time);
            Death();
        }

        private void Death() {
            Destroy(gameObject);
        }

        protected override void Start() {
            base.Start();
            _healthBar.SetMaxHealth(MaxHealth);
            OnEnemySpawn?.Invoke();
        }     
    }
}
