using System;
using UnityEngine;

namespace Game {

    public enum WaypointType {

        Lake,
        Mill,
        Well,
        Square,
        Church,
        Armory,
        WheatField,
        FamilyHouse,
        FarmerHouse,
        FishermanHouse,
    }
    
    [Serializable]
    public class Waypont {

        [SerializeField]
        private WaypointType _type;
        public WaypointType Type => _type;

        [SerializeField]
        private Vector2 _position;
        public Vector2 Position => _position;
    }
}
