using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG {
    public class HealthBar : MonoBehaviour {
        public Slider slider;

        public void SetMaxHealth(int health) {
            slider.maxValue = health;
            slider.value = 0;
        }
        public void SetHealth(int missingHealth) {
            slider.value = missingHealth;
        }
    }
}
