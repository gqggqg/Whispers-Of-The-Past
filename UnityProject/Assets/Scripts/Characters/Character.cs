using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public abstract class Character : MonoBehaviour {

        

        // Stats
        [SerializeField]
        public int maxHealth;
        public int currentHealth;
        
        [SerializeField]
        public int baseDamage;
        public int currentDamage;

        [SerializeField]
        public int baseMovementSpeed;


    }
}