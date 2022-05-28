using UnityEngine;
using System;
namespace Game {

    public class Player : Character {

        [SerializeField]
        private HealthBar _healthBar;

        [SerializeField]
        private Weapon _weapon;
        public Weapon Weapon => _weapon;

        [SerializeField]
        private Movement _movement;
        public Movement Movement => _movement;

        [SerializeField]
        private KeyCode _attackKey;

        [SerializeField]
        private KeyCode _interactionKey;

        [SerializeField]
        private KeyCode _switchWeaponKey;

        [SerializeField]
        private KeyCode _reloadWeaponKey;

        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";


        public event Action OnMove;

        private void Update() {
            if (Input.GetKey(_attackKey)) {
                _weapon.Attack();
            }
            if (Input.GetKey(_reloadWeaponKey)) {
                _weapon.Reload();
            }

            OnMove?.Invoke();
            

        }



        public KeyCode InteractionKey => _interactionKey;
        public KeyCode AttackKey => _attackKey;
        public bool CanAttack => canAttack;

        /// 
        private bool canAttack = true;
        //
        protected override void Start() {
            base.Start();
            _movement.BaseSpeed = BaseSpeed;
            _healthBar.SetMaxHealth(MaxHealth);
            OnMove += DoMove;
        }

        public void DoMove() {
            Vector2 direction = new Vector2(Input.GetAxisRaw(HORIZONTAL_AXIS_NAME), Input.GetAxisRaw(VERTICAL_AXIS_NAME));
            _movement.MoveToDirection(direction);
        }
        public void TakeDamage(int damage) {
            _currentHealth -= damage;
            _healthBar.SetHealth(_currentHealth);
        }
    }
}
