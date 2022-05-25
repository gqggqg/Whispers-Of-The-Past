namespace Game.AI {

    public static class AIPropertyFactory {

        public static IEvaluatedProperty CreateProperty(AIEvaluatedPropertyType type) {
            return type switch {
                AIEvaluatedPropertyType.DistanceToFriend => new DistanceToFriendAIProperty(),
                AIEvaluatedPropertyType.DistanceToEnemy => new DistanceToEnemyAIProperty(),
                AIEvaluatedPropertyType.RelationToReligion => new RelationToReligionAIProperty(),
                AIEvaluatedPropertyType.LoveToEat => new LoveToEatAIProperty(),
                _ => null,
            };
        }
    }
}
