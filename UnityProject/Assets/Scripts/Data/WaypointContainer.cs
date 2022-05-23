using System.Collections.Generic;
using UnityEngine;

namespace Game {

    [CreateAssetMenu(fileName = "WaypointContainer", menuName = "Data/WaypointContainer")]
    public class WaypointContainer : InitializableScriptableObject {

        [SerializeField]
        private List<Waypont> _waypoints;


        private Dictionary<WaypointType, Vector2> _positionByWaypointTypesCache;
        public Dictionary<WaypointType, Vector2> PositionByWaypointTypesCache => _positionByWaypointTypesCache;


        protected override void OnInit() {
            InitCache();
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
