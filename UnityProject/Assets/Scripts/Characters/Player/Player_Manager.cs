using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {

    public class Player_Manager : Character {
        [SerializeField]
        private KeyCode _interactionKey;

        [SerializeField]
        private KeyCode _attackKey;

        [SerializeField]
        private KeyCode _switchWeaponKey;

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
        }
        // Update is called once per frame
        void Update() {

        }

        void Takedamage(int damage) {
            currentHealth -= damage;
            healthBar.SetHealth(maxHealth - currentHealth); 
        }
    }
}
