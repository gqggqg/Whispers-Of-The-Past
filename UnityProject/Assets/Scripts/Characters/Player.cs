using UnityEngine;

namespace Game {

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

        [SerializeField]
        private KeyCode _reloadWeaponKey;


        private void Update() {
            if (Input.GetKey(_attackKey)) {
                _weapon.Attack();
            }
            if (Input.GetKey(_reloadWeaponKey)) {
                _weapon.Reload();
            }
        }

        public KeyCode InteractionKey => _interactionKey;
        public KeyCode AttackKey => _attackKey;
        public KeyCode SwitchWeaponKey => _switchWeaponKey;
        public bool CanAttack => canAttack;

        /// 
        private bool canAttack = true;
        //
        protected override void Start() {
            base.Start();

            _healthBar.SetMaxHealth(MaxHealth);
            
        }

        public void TakeDamage(int damage) {
            _currentHealth -= damage;
            _healthBar.SetHealth(_currentHealth);
        }
    }
}
