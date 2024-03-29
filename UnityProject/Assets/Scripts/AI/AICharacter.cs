using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game.AI {

    public class AICharacter : MonoBehaviour {

        [SerializeField]
        private float _baseSpeed;
        public float BaseSpeed => _baseSpeed;

        [SerializeField]
        private List<AIFloatProperty> _stats;


        [NonSerialized]
        private bool _isMove = false;
        public bool IsMove => _isMove;

        [NonSerialized]
        private Vector3 _targetPosition;


        private Dictionary<AIVariabledPropertyType, AIFloatProperty> _statsByType;


        private void Awake() {
            InitStats();
        }

        private void Update() {
            UpdateStats();
            if (_isMove) {
                MoveToTarget();
            }
        }

        public void SetTargetPosition(Vector3 position) {
            _targetPosition = position;
            _isMove = true;
        }

        public void ChangeStatToDelta(AIVariabledPropertyType type, float deltaValue) {
            if (_statsByType.ContainsKey(type)) {
                _statsByType[type].ChangeByDeltaValue(deltaValue);
            }
        }

        public AIFloatProperty GetStat(AIVariabledPropertyType type) {
            if (_statsByType.ContainsKey(type)) {
                return _statsByType[type];
            }

            return null;
        }

        private void InitStats() {
            _statsByType = new Dictionary<AIVariabledPropertyType, AIFloatProperty>();
            foreach (var need in _stats) {
                need.Init();
                if (!_statsByType.ContainsKey(need.Type)) {
                    _statsByType.Add(need.Type, need);
                }
            }
        }
            
        private void UpdateStats() {
            foreach (var need in _stats) {
                need.Update();
            }
        }

        private void MoveToTarget() {
            float distanceDelta = _baseSpeed * TimeUtility.DeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, distanceDelta);

            if (transform.position == _targetPosition) {
                _isMove = false;
            }
        }
    }
}
