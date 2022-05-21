using UnityEngine;

namespace RPG {

    public class Enemy : Character {

        [SerializeField]
        public HealthBar _healthBar;

        public void TakeDamage(int damage) {
            _currentHealth -= damage;
            _healthBar.SetHealth(MaxHealth - _currentHealth);

            if (_currentHealth <= 0) {
                Destroy(gameObject);
            }
        }

        protected override void Start() {
            base.Start();
            _healthBar.SetMaxHealth(MaxHealth);
        }     
    }
}
