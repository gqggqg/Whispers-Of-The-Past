using UnityEngine;
using System;

namespace RPG {

    public class Enemy : Character {

<<<<<<< Updated upstream
        [SerializeField]
        public HealthBar _healthBar;


        public event Action OnEnemyDeath;

        public void TakeDamage(int damage) {
            _currentHealth -= damage;

            _healthBar.SetHealth(MaxHealth - _currentHealth);
            if (_currentHealth <= 0) {
                OnEnemyDeath?.Invoke();
            }   
=======
        public HealthBar healthBar;
        public event Action OnEnemyDeath;

        public void TakeDamage(int damage) {
            currentHealth -= damage;

            healthBar.SetHealth(maxHealth - currentHealth);
            if (currentHealth <= 0) {
                OnEnemyDeath?.Invoke();
            }   
        }
        // Start is called before the first frame update
        void Start() {
            currentHealth = maxHealth;

        void Death() {
            Destroy(gameObject);
        }

        protected override void Start() {
            base.Start();
            _healthBar.SetMaxHealth(MaxHealth);
        }     
    }
}
