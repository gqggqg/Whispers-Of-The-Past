using System.Collections;
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
        protected float _changePerMinute;


        private float _currentValue;
        public float CurrentValue {
            get { return _currentValue; }
            set {
                _currentValue = 0f;
                ChangeByDeltaValue(value);
            }
        }


        private float RandomValue => Random.Range(_minValue, _maxValue);


        public override void Init() {
            _currentValue = _randomizeStartValue ? RandomValue : _startValue;
        }

        public override void Update() {
            var deltaValue = TimeUtility.DeltaTime * _changePerMinute;
            UpdateValue(deltaValue);
        }

        public void ChangeByDeltaValue(float deltaValue) {
            UpdateValue(deltaValue);
        }

        public void ChangeValueInPeriodOfTime(float value, float duration) {
            AIPropertyCorotineLauncher.Instance.StartCoroutine(ChangeValueInPeriodOfTimeCoroutine(value, duration));
        }

        protected override float EvaluateValue(AIContext context) {
            return (_currentValue - _minValue) / (_maxValue - _minValue);
        }

        private void UpdateValue(float deltaValue) {
            _currentValue += deltaValue;
            _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
        }

        private IEnumerator ChangeValueInPeriodOfTimeCoroutine(float value, float duration) {    
            var deltaValue = value / duration;
            var timer = 0f;

            _changePerMinute += deltaValue;
            while (timer < duration) {
                timer += TimeUtility.DeltaTime;
                yield return null;
            }
            _changePerMinute -= deltaValue;
        }
    }
}
