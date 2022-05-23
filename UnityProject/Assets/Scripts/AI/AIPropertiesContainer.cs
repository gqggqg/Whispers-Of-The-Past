using System.Collections.Generic;

namespace Game.AI {

    public class AIPropertiesContainer {

        private Dictionary<AIPropertyType, AIProperty> _propeties = new Dictionary<AIPropertyType, AIProperty>();

        public void AddProperty(AIPropertyType type) {
            if (_propeties.ContainsKey(type)) {
                return;
            }

            var property = AIPropertyFactory.CreateProperty(type);
            _propeties.Add(type, property);
        }

        public AIProperty GetProperty(AIPropertyType type) {
            if (_propeties.ContainsKey(type)) {
                return _propeties[type];
            }

            return null;
        }

        public void EvaluateProperties(AIContext context) {
            foreach (var property in _propeties.Values) {
                property.Evaluate(context);
            }
        }
    }
}
