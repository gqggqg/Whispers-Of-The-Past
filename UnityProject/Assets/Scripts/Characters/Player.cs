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

<<<<<<< Updated upstream


        private void Update() {
            if (Input.GetKeyDown(_attackKey)) {
                _weapon.Shoot();
            }
=======
        public KeyCode InteractionKey => _interactionKey;
        public KeyCode AttackKey => _attackKey;
        public KeyCode SwitchWeaponKey => _switchWeaponKey;
        public bool CanAttack => canAttack;

        /// 
        private bool canAttack = true;
        //
        public HealthBar healthBar;
        void Start() {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
>>>>>>> Stashed changes
        }

        public KeyCode InteractionKey => _interactionKey;
        public KeyCode AttackKey => _attackKey;
        public KeyCode SwitchWeaponKey => _switchWeaponKey;
        public bool CanAttack => canAttack;

        /// 
        private bool canAttack = true;
        //
        public HealthBar healthBar;
        protected override void Start() {
            base.Start();
            _healthBar.SetMaxHealth(MaxHealth);
        }

        public void TakeDamage(int damage) {
            _currentHealth -= damage;
            _healthBar.SetHealth(MaxHealth - _currentHealth);
        }
    }
}
