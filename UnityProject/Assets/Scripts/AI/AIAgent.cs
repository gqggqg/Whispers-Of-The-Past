using UnityEngine;

namespace Game.AI {

    public class AIAgent : MonoBehaviour {

        [SerializeField]
        private AIAction[] _actions;


        private AIAction _topAction;
        public AIAction TopAction => _topAction;

        private bool _isActionChanged;
        public bool IsActionChanged => _isActionChanged;


        public void Init(AIPropertyContainer propertyContainer) {
            InitActions(propertyContainer);
        }

        public void UpdateTopAction() {
            var previousActopn = _topAction;
            var topScore = 0f;

            if (_topAction != null) {
                _topAction.Evaluate();
                topScore = _topAction.Score + _topAction.Inertia;
            }

            for (int i = 0; i < _actions.Length; i++) {
                if (!_actions[i].Enable || _actions[i] == _topAction) {
                    continue;
                }

                _actions[i].Evaluate();
                var score = _actions[i].Score;

                if (score > topScore) {
                    _topAction = _actions[i];
                    topScore = score;
                }
            }

            _isActionChanged = previousActopn != _topAction;
        }

        private void InitActions(AIPropertyContainer propertyContainer) {
            for (int i = 0; i < _actions.Length; i++) {
                InitActionConsiderations(_actions[i].Considerations, propertyContainer);
            }
        }

        private void InitActionConsiderations(AIConsideration[] considerations, AIPropertyContainer propertyContainer) {
            for (int i = 0; i < considerations.Length; i++) {
                considerations[i].Init(propertyContainer);
            }
        }
    }
}
