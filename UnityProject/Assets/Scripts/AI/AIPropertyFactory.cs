namespace Game.AI {

    public static class AIPropertyFactory {

        public static AIProperty CreateProperty(AIPropertyType type) {
            return type switch {
                AIPropertyType.DistanceToLake => new DistanceToLakeAIProperty(),
                AIPropertyType.DistanceToFishermanHouse => new DistanceToFishermanHouseAIProperty(),
                _ => null,
            };
        }
    }
}
