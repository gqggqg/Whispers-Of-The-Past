using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour {

    void OnTriggerEnter2D() {
        PlayerActionButton.ActivateActionButton();
    }

    private void OnTriggerExit2D() {
        PlayerActionButton.DeactivateActionButton();
    }
}
