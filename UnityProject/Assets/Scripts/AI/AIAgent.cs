using UnityEngine;

namespace Game.AI {

    public class AIAgent : MonoBehaviour {

		[SerializeField]
		private AIAction[] _actions;

        private AIAction _topAction;
        public AIAction TopAction => _topAction;


        private AIPropertiesContainer _properties;


        private void Start() {
            InitProperties();
        }

        private void InitProperties() {
            _properties = new AIPropertiesContainer();
            foreach (var action in _actions) {
                foreach (var consideration in action.Considerations) {
                    _properties.AddProperty(consideration.PropertyType);
                }
            }
        }

        public void UpdateAgent(AIContext context) {
            UpdateProperties(context);
            UpdateTopAction();
        }

        private void UpdateProperties(AIContext context) {
            _properties.EvaluateProperties(context);
        }

        private void UpdateTopAction() {
            var topScore = 0f;

            if (_topAction != null) {
                _topAction.Evaluate(_properties);
                topScore = _topAction.Score + _topAction.Inertia;
            }

            for (int i = 0; i < _actions.Length; i++) {
                if (!_actions[i].Enable || _actions[i] == _topAction) {
                    continue;
                }

                _actions[i].Evaluate(_properties);
                var score = _actions[i].Score;

                if (score > topScore) {
                    _topAction = _actions[i];
                    topScore = score;
                }
            }
        }

        public float GetActionScore(AIActionType type) {
            for (int i = 0; i < _actions.Length; i++) {
                if (_actions[i].Type == type) {
                    return _actions[i].Score;
                }
            }

            return 0f;
        }
    }
}
