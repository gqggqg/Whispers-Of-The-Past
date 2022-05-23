using UnityEngine;
using System;
using System.Collections;


namespace Game {
    public class Enemy : Character {
        [SerializeField]
        protected HealthBar _healthBar;

        [SerializeField]
        protected EnemyWeapon _weapon;

        public event Action OnEnemyDeath;
        public event Action OnEnemySpawn;
        public event Action OnAttackRangeDetect;

        protected IEnumerator AttackRangeDetect() {
            OnAttackRangeDetect?.Invoke();
            yield return new WaitForSeconds(2f);
        }
        public void TakeDamage(int damage) {
            _currentHealth -= damage;

            _healthBar.SetHealth(MaxHealth - _currentHealth);
            if (_currentHealth <= 0) {
                OnEnemyDeath?.Invoke();
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
