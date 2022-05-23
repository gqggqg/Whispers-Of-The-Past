namespace Game.AI {

    public abstract class AIProperty {

        private float _normalizedValue;
        public float NormalizedValue => _normalizedValue;

        public void Evaluate(AIContext context) {
            _normalizedValue = EvaluateValue(context);
        }

        protected abstract float EvaluateValue(AIContext context);
    }
}
