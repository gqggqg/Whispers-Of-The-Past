using UnityEngine;

namespace Game.AI {

    public abstract class AIVariabledPropertyBase : ScriptableObject, IEvaluatedProperty, IVariabledProperty {

        [SerializeField]
        private AIVariabledPropertyType _type;
        public AIVariabledPropertyType Type => _type;

        [SerializeField]
        protected bool _randomizeStartValue;

        [SerializeField]
        [Tooltip("For a boolean property use 0 or 1")]
        protected float _startValue;


        private float _normalizedValue;
        public float NormalizedValue => _normalizedValue;


        public void Evaluate(AIContext context) {
            _normalizedValue = EvaluateValue(context);
        }

        public abstract void Init();

        public abstract void Update();

        protected abstract float EvaluateValue(AIContext context);
    }
}
