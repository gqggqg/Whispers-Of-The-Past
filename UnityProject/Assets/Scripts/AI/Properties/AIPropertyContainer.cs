using System.Collections.Generic;
using UnityEngine;

namespace Game.AI {

    public class AIPropertyContainer {

        private Dictionary<AIPropertyType, IConsiderationProperty> _propertyByTypeCache;

        public AIPropertyContainer(AINeed[] needs) {
            InitCache(needs);
        }

        private void InitCache(AINeed[] needs) {
            _propertyByTypeCache = new Dictionary<AIPropertyType, IConsiderationProperty>();
            foreach (var need in needs) {
                if (!_propertyByTypeCache.ContainsKey(need.PropertyType)) {
                    _propertyByTypeCache.Add(need.PropertyType, need);
                }
            }
        }

        public void AddProperty(AIPropertyType propertyType) {
            if (_propertyByTypeCache.ContainsKey(propertyType)) {
                return;
            }

            var property = AIPropertyFactory.CreateProperty(propertyType);
            if (property == null) {
                Debug.LogWarningFormat("AIPropertyFactory doesn't contains {0}.", propertyType);
                return;
            }

            _propertyByTypeCache.Add(propertyType, property);
        }

        public void EvaluateProperties(AIContext context) {
            foreach (var property in _propertyByTypeCache.Values) {
                property.Evaluate(context);
            }
        }

        public IConsiderationProperty GetProperty(AIPropertyType propertyType) {
            if (_propertyByTypeCache.ContainsKey(propertyType)) {
                return _propertyByTypeCache[propertyType];
            }

            return null;
        }
    }
}
