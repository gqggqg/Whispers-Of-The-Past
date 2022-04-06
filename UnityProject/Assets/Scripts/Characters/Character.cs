using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public abstract class Character : MonoBehaviour {

        public Animator characterAnimator;

        // Stats
        [SerializeField]
        public int maxHealth = 10;
        public int currentHealth;
        
        [SerializeField]
        public int baseDamage = 1;
        public int currentDamage;

        [SerializeField]
        public int baseMovementSpeed = 40;

        private bool _facingRight;
    }
}