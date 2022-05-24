namespace Game.AI {

    public static class AIPropertyFactory {

        public static IConsiderationProperty CreateProperty(AIPropertyType type) {
            return type switch {
                AIPropertyType.DistanceToFriend => new DistanceToFriendAIProperty(),
                AIPropertyType.DistanceToEnemy => new DistanceToEnemyAIProperty(),
                AIPropertyType.RelationToReligion => new RelationToReligionAIProperty(),
                AIPropertyType.LoveToEat => new LoveToEatAIProperty(),
                _ => null,
            };
        }
    }
}
