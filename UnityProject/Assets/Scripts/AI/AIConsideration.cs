using System;
using UnityEngine;

namespace Game.AI {

    [Serializable]
    public class AIConsideration {

        [Header("Consideration")]
        [SerializeField]
        private bool _enabled = true;

        [SerializeField]
        private AIConsiderationType _type;
        public AIConsiderationType Type => _type;

        [Header("Boolean Type")]
        [SerializeField]
        private float _value = 1f;

        [Header("Weighted Type")]
        [SerializeField]
        private float _weight = 1.0f;
        public float Weight => _weight;

        [SerializeField]
        private bool _veto;
        public bool Veto => _veto;

        [SerializeField]
        private AnimationCurve _curve;

        [Header("Property")]
        [SerializeField]
        private AIEvaluatedPropertyType _propertyType;
        public AIEvaluatedPropertyType PropertyType => _propertyType;

        [SerializeField]
        private AIVariabledPropertyBase _variabledProperty;

        [SerializeField]
        private bool _isAnotherPersonProperty;


        private IEvaluatedProperty _property;


        public bool Enabled {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public bool IsBool => _type == AIConsiderationType.Boolean;


        public void Init(AIPropertyContainer propertyContainer) {
            TryInitProperty();

            if (_property != null) {
                propertyContainer.TryAddProperty(_propertyType, _property);
            }
        }

        public float Evaluate() {
            if (!Enabled || _property == null) {
                return 0f;
            }

            if (IsBool) {
                return _property.NormalizedValue == _value ? 1f : 0f;
            }

            return _curve.Evaluate(_property.NormalizedValue);
        }

        private void TryInitProperty() {
            if (_variabledProperty != null && !_isAnotherPersonProperty &&
                _variabledProperty is IVariabledProperty property) {
                _property = property;
                return;
            }

            _property = AIPropertyFactory.CreateProperty(_propertyType);
        }
    }
}
