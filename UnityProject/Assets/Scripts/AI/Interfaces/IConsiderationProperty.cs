namespace Game.AI {

    public interface IConsiderationProperty {

        public float NormalizedValue { get; }
        public void Evaluate(AIContext context);
    }
}
