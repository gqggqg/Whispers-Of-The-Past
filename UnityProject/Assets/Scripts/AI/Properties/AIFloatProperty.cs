using UnityEngine;
using Utils;

namespace Game.AI {

    [CreateAssetMenu(menuName = "Data/AI/Properties/Float Property")]
    public class AIFloatProperty : AIVariabledPropertyBase {

        [SerializeField]
        protected float _minValue;

        [SerializeField]
        protected float _maxValue;

        [SerializeField]
        protected float _changePerSecond;


        private float _currentValue;
        public float CurrentValue => _currentValue;


        private float RandomValue => Random.Range(_minValue, _maxValue);


        public override void Init() {
            _currentValue = _randomizeStartValue ? RandomValue : _startValue;
        }

        public override void Update() {
            var deltaValue = TimeUtility.DeltaTime * _changePerSecond;
            UpdateValue(deltaValue);
        }

        public void ChangeByDeltaValue(float deltaValue) {
            UpdateValue(deltaValue);
        }

        protected override float EvaluateValue(AIContext context) {
            return (_currentValue - _minValue) / (_maxValue - _minValue);
        }

        private void UpdateValue(float deltaValue) {
            _currentValue += deltaValue;
            _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
        }
    }
}
