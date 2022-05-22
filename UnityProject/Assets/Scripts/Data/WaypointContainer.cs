using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    [CreateAssetMenu(fileName = "WaypointContainer", menuName = "Data/WaypointContainer")]
    public class WaypointContainer : ScriptableObject {

        [SerializeField]
        private List<Waypont> _waypoints;


        [NonSerialized]
        private bool _init = false;


        private Dictionary<WaypointType, Vector2> _positionByWaypointTypesCache;
        public Dictionary<WaypointType, Vector2> PositionByWaypointTypesCache => _positionByWaypointTypesCache;


        public void Init() {
            if (_init) {
                return;
            }

            InitCache();
            _init = true;
        }


        public Vector2 GetPosition(WaypointType waypointType) {
            if (_positionByWaypointTypesCache.ContainsKey(waypointType)) {
                return _positionByWaypointTypesCache[waypointType];
            }

            Debug.LogWarning($"{GetType()} doesn't contain a {waypointType} waypoint.");
            return Vector2.zero;
        }

        private void InitCache() {
            _positionByWaypointTypesCache = new Dictionary<WaypointType, Vector2>();
            foreach (var waypoint in _waypoints) {
                if (!_positionByWaypointTypesCache.ContainsKey(waypoint.Type)) {
                    _positionByWaypointTypesCache.Add(waypoint.Type, waypoint.Position);
                }
            }
        }
    }
}
