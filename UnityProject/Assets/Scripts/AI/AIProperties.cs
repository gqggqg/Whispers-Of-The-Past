using UnityEngine;

namespace Game.AI {

    public enum AIPropertyType {

        DistanceToLake,
        DistanceToFishermanHouse
    }

    public class DistanceToLakeAIProperty : AIProperty {

        protected override float EvaluateValue(AIContext context) {
            var distance = Vector2.Distance(context.character.transform.position, context.waypointContainer.GetPosition(WaypointType.Lake));
            return Mathf.Clamp01(distance);
        }
    }

    public class DistanceToFishermanHouseAIProperty : AIProperty {

        protected override float EvaluateValue(AIContext context) {
            var distance = Vector2.Distance(context.character.transform.position, context.waypointContainer.GetPosition(WaypointType.FishermanHouse));
            return Mathf.Clamp01(distance);
        }
    }
}
