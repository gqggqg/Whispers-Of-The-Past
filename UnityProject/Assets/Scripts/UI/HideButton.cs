using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {

    [RequireComponent(typeof(Button))]
    public class HideButton : MonoBehaviour {

        [SerializeField]
        private GameObject _hiddenObject;

        private Button _button;
        private bool _isActivate;


        private void Awake() {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
            _isActivate = _hiddenObject.activeSelf;
        }

        private void OnClick() {
            _isActivate = !_isActivate;
            _hiddenObject.SetActive(_isActivate);
        }
    }
}
