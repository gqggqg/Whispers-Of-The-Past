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


        private Dictionary<AIVariabledPropertyType, AIFloatProperty> _statsByType;


        [NonSerialized]
        private bool _isMove = false;
        public bool IsMove => _isMove;

        [NonSerialized]
        private Vector3 _targetPosition;
        public Vector3 TargetPosition {
            get {
                return _targetPosition;
            }
            set {
                _isMove = true;
                _targetPosition = value;
                Debug.Log($"New target: {value}");
            }
        }


        private void Awake() {
            InitStats();
        }

        private void Update() {
            UpdateStats();
            if (_isMove) {
                MoveToTarget();
            }
        }

        public void MoveToTarget() {
            float step = _baseSpeed * TimeUtility.DeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
            if (transform.position == _targetPosition) {
                Debug.Log("Path end");
                _isMove = false;
            }
        }

        public void ChangeNeedToDelta(AIVariabledPropertyType type, float deltaValue) {
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
    }
}
