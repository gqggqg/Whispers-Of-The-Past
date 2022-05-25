using UnityEngine;

namespace Game.AI {

    public class AIBehaviour : MonoBehaviour {

        [SerializeField]
        private AICharacter _character;

        [SerializeField]
        private AIAgent _agent;


        private AIActionTimer _actionTimer;
        public AIActionTimer ActionTimer => _actionTimer;


        private AIPropertyContainer _propertyContainer;
        private AIAction _topAction;
        private AIContext _context;

        private bool _isActionExecution;


        private void Awake() {
            Init();
        }

        private void Update() {
            _actionTimer.Update();
            UpdateAI();
        }

        private void Init() {
            _actionTimer = new AIActionTimer();
            _propertyContainer = new AIPropertyContainer();
            _agent.Init(_propertyContainer);

            _context = new AIContext() {
                character = _character,
            };
        }

        public void UpdateAI() {
            if (_topAction == null) {
                UpdateTopAction();
                return;
            }

            if (_character.IsMove && !_topAction.MotionInterrupted) {
                return;
            }

            if (_character.IsMove && _topAction.MotionInterrupted) {
                UpdateTopAction();
            }

            if (_actionTimer.IsRun) {
                return;
            }

            if (!_isActionExecution) {
                ExecuteTopAction();
                return;
            }

            UpdateTopAction();
        }

        private void UpdateTopAction() {
            UpdateContext();

            _propertyContainer.EvaluateProperties(_context);
            _agent.UpdateTopAction();

            _isActionExecution = false;

            if (_agent.IsActionChanged) {
                _topAction = _agent.TopAction;
                TryMoveToActionPoint();
            }
        }

        private void UpdateContext() {
            // Find nearest person
            // Find nearest friend
            // Find points of interest
        }

        private void TryMoveToActionPoint() {
            _character.TargetPosition = _topAction.InterestPoint;
        }

        private void ExecuteTopAction() {
            _isActionExecution = true;
            _actionTimer.Start(_topAction.Duration);

            switch (_agent.TopAction.Type) {
                case AIActionType.EatAtTavern:
                    Debug.Log("EatAtTavern");
                    _character.ChangeNeedToDelta(AIVariabledPropertyType.Hunger, -50f);
                    break;
                case AIActionType.Sleep:
                    Debug.Log("Sleep");
                    _character.ChangeNeedToDelta(AIVariabledPropertyType.Energy, 80f);
                    break;
                case AIActionType.Work:
                    Debug.Log("Work");
                    _character.ChangeNeedToDelta(AIVariabledPropertyType.Hunger, 50f);
                    _character.ChangeNeedToDelta(AIVariabledPropertyType.Energy, -60f);
                    break;
            }
        }
    }
}
