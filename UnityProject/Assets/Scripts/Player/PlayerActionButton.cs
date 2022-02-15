using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionButton : MonoBehaviour {

    private static bool _isActive = false;

    public static void ActivateActionButton() {
        _isActive = true;
    }

    public static void DeactivateActionButton() {
        _isActive = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (_isActive) {
                Debug.Log("ActionButtonPressed!");
            }
        }
    }
}
