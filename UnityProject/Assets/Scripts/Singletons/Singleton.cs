using UnityEngine;

namespace Game {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

        private static bool _hasInstance;
        public static bool HasInstance => _hasInstance;


        private static T _instance;
        public static T Instance {
            get {
                if (!_hasInstance) {
                    _instance = FindObjectOfType<T>();
                }
                return _instance;
            }
        }


        protected virtual void Awake() {
            _instance = GetComponent<T>();
            _hasInstance = true;
        }

        protected virtual void OnDestroy() {
            _instance = null;
            _hasInstance = false;
        }
    }
}
