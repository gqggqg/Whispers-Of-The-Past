namespace Game.AI {

    public interface IEvaluatedProperty {

        public float NormalizedValue { get; }
        public void Evaluate(AIContext context);
    }
}
