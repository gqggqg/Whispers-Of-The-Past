using Utils;

namespace Game.AI {

    public class AIActionTimer {

        private float _time;
        public float Time => _time;

        private bool _isRun;
        public bool IsRun => _isRun;


        public void Update() {
            if (!_isRun) {
                return;
            }

            _time -= TimeUtility.DeltaTime;
            if (_time <= 0f) {
                Stop();
            }
        }

        public void Start(float duration) {
            _isRun = true;
            _time = duration;
        }

        private void Stop() {
            _isRun = false;
            _time = 0f;
        }
    }
}
