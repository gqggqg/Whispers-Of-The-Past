using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class Enemy : Character {

        public HealthBar healthBar;

        public void TakeDamage(int damage) {
            currentHealth -= damage;
            healthBar.SetHealth(maxHealth - currentHealth);

            if (currentHealth <= 0) {
                Destroy(gameObject);
            }   
        }
        // Start is called before the first frame update
        void Start() {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        // Update is called once per frame
        void Update() {

        }
        
    }
}