using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class WaypointContainer : Singleton<WaypointContainer> {

        [SerializeField]
        private List<Waypoint> _waypoints;


        private Dictionary<WaypointType, Vector3> _positionByWaypointTypes;
        public Dictionary<WaypointType, Vector3> PositionByWaypointTypes => _positionByWaypointTypes;


        protected override void Awake() {
            base.Awake();
            InitCache();
        }


        public Vector3 GetPosition(WaypointType waypointType) {
            if (_positionByWaypointTypes.ContainsKey(waypointType)) {
                return _positionByWaypointTypes[waypointType];
            }

            Debug.LogWarning($"{GetType()} doesn't contain a {waypointType} waypoint.");
            return Vector3.zero;
        }

        private void InitCache() {
            _positionByWaypointTypes = new Dictionary<WaypointType, Vector3>();
            foreach (var waypoint in _waypoints) {
                if (!_positionByWaypointTypes.ContainsKey(waypoint.Type)) {
                    _positionByWaypointTypes.Add(waypoint.Type, waypoint.Position);
                }
            }
        }
    }
}
