using System;
using UnityEngine;

namespace Game {

    [Serializable]
    public class Waypoint {

        [SerializeField]
        private WaypointType _type;
        public WaypointType Type => _type;

        [SerializeField]
        private Transform _point;
        public Vector3 Position => _point.position;
    }
}
