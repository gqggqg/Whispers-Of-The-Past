using UnityEngine;

namespace RPG {

    public class Player : Character {

        [SerializeField]
        private HealthBar _healthBar;

        [SerializeField]
        private Weapon _weapon;

        [SerializeField]
        private KeyCode _attackKey;

        [SerializeField]
        private KeyCode _interactionKey;

        [SerializeField]
        private KeyCode _switchWeaponKey;


        private void Update() {
            if (Input.GetKeyDown(_attackKey)) {
                _weapon.Shoot();
            }
        }

        public void TakeDamage(int damage) {
            _currentHealth -= damage;
            _healthBar.SetHealth(MaxHealth - _currentHealth);
        }
    }
}
