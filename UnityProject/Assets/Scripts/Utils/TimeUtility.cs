using UnityEngine;

namespace Utils {

    public static class TimeUtility {

        private static bool _isPause;
        public static bool IsPause => _isPause;

        public static float Speed { get; set; } = 1f;


        /// <summary>
        /// In minutes
        /// </summary>
        public static float DeltaTime {
            get {
                if (_isPause) {
                    return 0.0f;
                }

                if (Speed < 0.0f) {
                    return Time.deltaTime / (-Speed);
                }

                return Time.deltaTime * Speed;
            }
        }

        public static void Pause() {
            _isPause = true;
            Time.timeScale = 0.0f;
        }

        public static void UnPause() {
            _isPause = false;
            Time.timeScale = 1.0f;
        }
    }
}
