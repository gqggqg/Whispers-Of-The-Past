using UnityEngine;

namespace Game {

    public abstract class Character : MonoBehaviour {

        [SerializeField]
        private int _baseSpeed;
        public int BaseSpeed => _baseSpeed;

        [SerializeField]
        private int _maxHealth;
        public int MaxHealth => _maxHealth;

        [SerializeField]
        private int _baseDamage;
        public int BaseDamage => _baseDamage;

        protected int _currentHealth;
        protected int _currentDamage;


        protected virtual void Start() {
            _currentHealth = _maxHealth;
            _currentDamage = _baseDamage;
        }
    }
}
