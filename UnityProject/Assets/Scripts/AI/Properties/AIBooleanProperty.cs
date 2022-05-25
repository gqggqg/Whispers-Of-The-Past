using UnityEngine;

namespace Game.AI {

    [CreateAssetMenu(menuName = "Data/AI/Properties/Boolean Property")]
    public class AIBooleanProperty : AIVariabledPropertyBase {

        private bool _currentValue;
        public bool CurrentValue {
            get { return _currentValue; }
            set { _currentValue = value; }
        }


        private bool RandomValue => Random.value > 0.5f;


        public override void Init() {
            _currentValue = _randomizeStartValue ? RandomValue : _startValue > 0.5f;
        }

        public override void Update() { }

        protected override float EvaluateValue(AIContext context) {
            return _currentValue ? 1.0f : 0.0f;
        }
    }
}
