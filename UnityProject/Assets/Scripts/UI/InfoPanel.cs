using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {

    public class InfoPanel : MonoBehaviour {

        [SerializeField]
        private Text _time;

        [SerializeField]
        private Text _weekday;


        private void Update() {
            UpdatePanelText();
        }

        private void UpdatePanelText() {
            _time.text = GetTimeString();
            _weekday.text = TimeManager.Instance.Weekday.ToString();
        }

        private string GetTimeString() {
            return GetTimeValueString(TimeManager.Instance.Hours) + ":" + 
                GetTimeValueString(TimeManager.Instance.Minutes);
        }

        private string GetTimeValueString(int value) {
            return (value < 10 ? "0" : "") + value.ToString();
        }
    }
}
