using UnityEngine;

namespace Game.AI {

    public enum AIActionType {

        Idle,
        Work,
        Sleep,
        GoToLake,
        GoToMill,
        GoToWell,
        GoToSquare,
        GoToChurch,
        GoToArmory,
        GoToWheatField,
        GoToFamilyHouse,
        GoToFarmerHouse,
        GoToFishermanHouse,
    }

    [CreateAssetMenu(menuName = "Data/AI/Action")]
    public class AIAction : ScriptableObject {

        [SerializeField]
        private bool _enable = true;
        public bool Enable => _enable;

        [SerializeField]
        private float _inertia;
        public float Inertia => _inertia;

        [SerializeField]
        private AIActionType _type;
        public AIActionType Type => _type;

        [SerializeField]
        private AIConsideration[] _considerations;
        public AIConsideration[] Considerations => _considerations;


        private float _score;
        public float Score => _enable ? _score : 0f;


        public void Evaluate(AIPropertiesContainer properties) {
            if (!_enable) {
                return;
            }

            CalculateScore(properties);
        }

        private void CalculateScore(AIPropertiesContainer properties) {
            _score = 0f;

            var considerationCount = 0;

            for (int i = 0; i < _considerations.Length; i++) {
                if (!_considerations[i].Enabled) {
                    continue;
                }

                var isBool = _considerations[i].Type == AIConsiderationType.Boolean;
                var score = _considerations[i].Evaluate(properties);

                if (score == 0f && (_considerations[i].Veto || isBool)) {
                    _score = 0f;
                    return;
                }

                if (!isBool) {
                    _score += score * _considerations[i].Weight;
                    considerationCount++;
                }
            }

            _score /= considerationCount;
        }
    }
}
