using UnityEngine;
using Utils;

namespace Game.AI {

    [CreateAssetMenu(menuName = "Data/AI/Property/Needs")]
    public class AINeed : ScriptableObject, IConsiderationProperty, ICharacterNeed {

        [SerializeField]
        private AIPropertyType _propertyType;
        public AIPropertyType PropertyType => _propertyType;

        [SerializeField]
        private float _minValue = 0.0f;

        [SerializeField]
        private float _maxValue = 100.0f;

        [SerializeField]
        private float _startValue = 50.0f;

        [SerializeField]
        private bool _randomizeStartValue;

        [SerializeField]
        private float _changePerSecond;


        private float _normalizedValue;
        public float NormalizedValue => _normalizedValue;

        private float _currentValue;

        private float RandomValue => Random.Range(_minValue, _maxValue);


        public void Init() {
            _currentValue = _randomizeStartValue ? _startValue : RandomValue;
        }

        public void Update() {
            var deltaValue = TimeUtility.DeltaTime * _changePerSecond;
            UpdateValue(deltaValue);
        }

        public void ChangeByDeltaValue(float deltaValue) {
            UpdateValue(deltaValue);
        }

        public void Evaluate(AIContext context) {
            _normalizedValue = EvaluateValue();
        }

        private void UpdateValue(float deltaValue) {
            _currentValue += deltaValue;
            Mathf.Clamp(_currentValue, _minValue, _maxValue);
        }

        private float EvaluateValue() {
            return (_currentValue - _minValue) / (_currentValue - _maxValue);
        }
    }
}
