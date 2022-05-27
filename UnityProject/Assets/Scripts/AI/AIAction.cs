using UnityEngine;

namespace Game.AI {

    [CreateAssetMenu(menuName = "Data/AI/Action")]
    public class AIAction : ScriptableObject {

        [SerializeField]
        private AIActionType _type;
        public AIActionType Type => _type;

        [SerializeField]
        private bool _enable = true;
        public bool Enable => _enable;

        [SerializeField]
        private bool _motionInterrupted;
        public bool MotionInterrupted => _motionInterrupted;

        [SerializeField]
        private bool _actionInterrupted;
        public bool ActionInterrupted => _actionInterrupted;

        [SerializeField]
        private float _duration;
        public float Duration => _duration;
         
        [SerializeField]
        private float _inertia;
        public float Inertia => _inertia;

        [SerializeField]
        private WaypointType _interestPointType;
        public WaypointType InterestPointType => _interestPointType;

        [SerializeField]
        private AIConsideration[] _considerations;
        public AIConsideration[] Considerations => _considerations;


        private float _score;
        public float Score => _enable ? _score : 0f;


        public void Evaluate() {
            if (!_enable) {
                return;
            }

            CalculateScore();
        }

        private void CalculateScore() {
            _score = 0f;

            var considerationCount = 0;

            for (int i = 0; i < _considerations.Length; i++) {
                if (!_considerations[i].Enabled) {
                    continue;
                }

                var score = _considerations[i].Evaluate();
                var isBool = _considerations[i].IsBool;

                if (score == 0f && (_considerations[i].Veto || isBool)) {
                    _score = 0f;
                    return;
                }

                if (!isBool) {
                    _score += score * _considerations[i].Weight;
                    considerationCount++;
                }
            }

            if (considerationCount != 0) {
                _score /= considerationCount;
            }
        }
    }
}
