using UnityEngine;

namespace Game {

    public class ScriptableObjectsIniter : MonoBehaviour {

        [SerializeField]
        private InitializableScriptableObject[] _scriptableObjects;

        private void Awake() {
            foreach (var so in _scriptableObjects) {
                so.Init();
            }
        }
    }
}
