using System;
using UnityEngine;

namespace Game {

    public abstract class InitializableScriptableObject : ScriptableObject {

        [NonSerialized]
        private bool _init;

        public void Init() {
            if (_init) {
                return;
            }

            OnInit();
            _init = true;
        }

        protected abstract void OnInit();
    }
}
