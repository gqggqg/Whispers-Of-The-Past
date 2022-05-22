using UnityEngine;
using System;

namespace RPG {

    public class Enemy : Character {

<<<<<<< Updated upstream
        [SerializeField]
        public HealthBar _healthBar;

        public void TakeDamage(int damage) {
            _currentHealth -= damage;
            _healthBar.SetHealth(MaxHealth - _currentHealth);

            if (_currentHealth <= 0) {
                Destroy(gameObject);
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

            healthBar.SetMaxHealth(maxHealth);
            
        }

        void Death() {
            Destroy(gameObject);
>>>>>>> Stashed changes
        }

        protected override void Start() {
            base.Start();
            _healthBar.SetMaxHealth(MaxHealth);
        }     
    }
}
