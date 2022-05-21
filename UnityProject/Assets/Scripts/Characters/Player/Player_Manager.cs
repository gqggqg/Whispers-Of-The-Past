using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {

    public class Player_Manager : Character {

        public KeyCode interactionKey = KeyCode.E;
        public KeyCode attackKey = KeyCode.Mouse0;
        public KeyCode switchWeaponKey = KeyCode.LeftShift;
        /// ///////////////
        /// 
        public bool canAttack = false;
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
