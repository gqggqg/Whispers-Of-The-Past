using System;
using UnityEngine;

namespace Game.AI {

    public enum AIConsiderationType {

        Weighted,
        Boolean,
    }

    [Serializable]
    public class AIConsideration {

        [SerializeField]
        private AIPropertyType _propertyType;
        public AIPropertyType PropertyType => _propertyType;

        [Header("Consideration")]
        [SerializeField]
        private bool _enabled = true;
        public bool Enabled => _enabled;

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


        public float Evaluate(AIPropertiesContainer properties) {
            var property = properties.GetProperty(_propertyType);

            if (!_enabled || property == null) {
                return 0f;
            }

            if (_type == AIConsiderationType.Boolean) {
                return property.NormalizedValue == _value ? 1f : 0f;
            }

            return _curve.Evaluate(property.NormalizedValue);
        }
    }
}
