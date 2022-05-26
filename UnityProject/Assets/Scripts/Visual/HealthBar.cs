using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
    public class HealthBar : MonoBehaviour {
        [SerializeField]
        private float _maxHealth;

        [SerializeField]
        private float _currentHealth;

        [SerializeField]
        private SpriteRenderer _healthBar;

        [SerializeField]
        private SpriteRenderer _fill;

        private Vector3 _fillScale;
        private Vector3 _fillPosition;
        public void SetMaxHealth(float value) {
            _maxHealth = value;
            _currentHealth = _maxHealth;
            _fillScale = _fill.transform.localScale;
            _fillPosition = _fill.transform.localPosition;
        }

        public void SetHealth(float value) {
            _currentHealth = value;

            _fillScale.x = Mathf.Abs(1 - (_maxHealth - _currentHealth) / _maxHealth);
            if (_fillScale.x < 0f) {
                _fillScale.x = 0f;
            }
            _fill.transform.localScale = _fillScale;
        }

    }
}
