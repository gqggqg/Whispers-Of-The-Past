using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI
using UnityEngine.SceneManagement; //Scenes

public class PauseMenuCall : MonoBehaviour {

    private bool _isGamePaused = false;

    [SerializeField]
    private GameObject _pauseGameMenu; //PauseMenu object

    // Start is called before the first frame update
    void Start() {
        PauseMenu.onResume += ChangeMenuState;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
                ChangeMenuState();
            } 
    }

    public void ChangeMenuState() { //Using key ESC to open/close PauseMenu
        _isGamePaused = !_isGamePaused;
        if (_isGamePaused) {
            _pauseGameMenu.SetActive(true);
            Time.timeScale = 0f;
        } else if (!_isGamePaused) { //If ESC pressed when game continues the game pauses
            _pauseGameMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}