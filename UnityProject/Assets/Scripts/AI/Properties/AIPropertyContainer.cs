using System.Collections.Generic;

namespace Game.AI {

    public class AIPropertyContainer {

        private Dictionary<AIEvaluatedPropertyType, IEvaluatedProperty> _propertyByTypes = 
            new Dictionary<AIEvaluatedPropertyType, IEvaluatedProperty>();

        public void TryAddProperty(AIEvaluatedPropertyType type, IEvaluatedProperty property) {
            if (!_propertyByTypes.ContainsKey(type)) {
                _propertyByTypes.Add(type, property);
            }
        }

        public void EvaluateProperties(AIContext context) {
            foreach (var property in _propertyByTypes.Values) {
                property.Evaluate(context);
            }
        }

        public IEvaluatedProperty GetProperty(AIEvaluatedPropertyType type) {
            if (!_propertyByTypes.ContainsKey(type)) {
                return _propertyByTypes[type];
            }

            return null;
        }
    }
}
