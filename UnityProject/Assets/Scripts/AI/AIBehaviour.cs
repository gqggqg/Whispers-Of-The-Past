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

        private AIActionPhase _currentPhase;


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

            if (_currentPhase == AIActionPhase.Motion) {
                if (!_character.IsMove) {
                    StartActPhase();
                    return;
                }

                if (_topAction.MotionInterrupted) {
                    UpdateTopAction();
                    return;
                }
            }

            if (_currentPhase == AIActionPhase.Act) {
                if (_topAction.ActionInterrupted) {
                    UpdateTopAction();
                    return;
                }

                if (!_actionTimer.IsRun) {
                    UpdateTopAction();
                }
            }
        }

        private void UpdateTopAction() {
            UpdateContext();

            _propertyContainer.EvaluateProperties(_context);
            _agent.UpdateTopAction();

            if (_agent.IsActionChanged) {
                _topAction = _agent.TopAction;
                StartMotionPhase();
                return;
            }

            if (_actionTimer.IsRun) {
                return;
            }

            StartActPhase();
        }

        private void UpdateContext() {
            // Find nearest person
            // Find nearest friend
            // Find points of interest
        }

        private void StartMotionPhase() {
            _currentPhase = AIActionPhase.Motion;
            MoveToActionPoint();
        }

        private void StartActPhase() {
            _currentPhase = AIActionPhase.Act;
            ExecuteAction();
        }

        private void MoveToActionPoint() {
            var position = GetPositionForTopAction();
            _character.SetTargetPosition(position);
            _currentPhase = AIActionPhase.Motion;
        }

        private Vector3 GetPositionForTopAction() {
            return WaypointContainer.Instance.GetPosition(_topAction.InterestPointType);
        }

        private void ExecuteAction() {
            _actionTimer.Start(_topAction.Duration);

            switch (_agent.TopAction.Type) {
                case AIActionType.EatAtTavern:
                    ChangeStatAtTopAction(AIVariabledPropertyType.Hunger, -50f);
                    break;
                case AIActionType.Sleep:
                    ChangeStatAtTopAction(AIVariabledPropertyType.Energy, 80f);
                    break;
                case AIActionType.Work:
                    ChangeStatAtTopAction(AIVariabledPropertyType.Hunger, 50f);
                    ChangeStatAtTopAction(AIVariabledPropertyType.Energy, -60f);
                    break;
            }
        }

        private void ChangeStatAtTopAction(AIVariabledPropertyType type, float value) {
            var stat = _character.GetStat(type);
            stat.ChangeValueInPeriodOfTime(value, _topAction.Duration);
        }
    }
}
