using UnityEngine;
using UnityEngine.UI;

namespace Game.AI {

    public class AICharacterStatsPanel : MonoBehaviour {

        [SerializeField]
        private AICharacter _character;

        [SerializeField]
        private AIBehaviour _behaviour;

        [SerializeField]
        private AIAgent _agent;

        [SerializeField]
        private Slider _hungerSlider;

        [SerializeField]
        private Slider _energySlider;

        [SerializeField]
        private Text _actionText;

        [SerializeField]
        private Text _actionTimeText;


        private AIFloatProperty _hungerStat;
        private AIFloatProperty _energyStat;
        private AIActionTimer _actionTimer;


        private const string ACTION_PREFIX = "Action: ";
        private const string ACTION_TIME_PREFIX = "Action Time: ";
        private const string ACTION_TIME_POSTIX = " min.";


        private void Start() {
            _hungerStat = _character.GetStat(AIVariabledPropertyType.Hunger);
            _energyStat = _character.GetStat(AIVariabledPropertyType.Energy);
            _actionTimer = _behaviour.ActionTimer;
        }

        private void Update() {
            _actionText.text = ACTION_PREFIX + _agent.TopAction?.Type;
            _actionTimeText.text = ACTION_TIME_PREFIX + (int)_actionTimer.Time + ACTION_TIME_POSTIX;
            _hungerSlider.value = _hungerStat.CurrentValue;
            _energySlider.value = _energyStat.CurrentValue;
        }
    }
}
