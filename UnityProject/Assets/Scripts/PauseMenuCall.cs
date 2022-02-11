using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI
using UnityEngine.SceneManagement; //Scenes

public class PauseMenuCall : MonoBehaviour {

    private bool _isGamePaused; //Check if game is paused

    [SerializeField]
    private GameObject _pauseGameMenu; //PauseMenu object

    // Start is called before the first frame update
    void Start() {
        _pauseGameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        ActiveMenu();
    }

    public void ActiveMenu() {
        if (Input.GetKeyDown(KeyCode.Escape)) { //Using key ESC to open/close PauseMenu
            _isGamePaused = !_isGamePaused;
            if (_isGamePaused) {
                _pauseGameMenu.SetActive(true);
                Time.timeScale = 0f;
            } else { //If ESC pressed when game continues the game pauses
                _pauseGameMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
/*
    public void Resume() {
         //PauseMenu is inactive
        Time.timeScale = 1f; //Time is in a regular regime
        _pauseGame = false; //Game is not paused
    }

    public void Pause() {
        _pauseGameMenu.SetActive(true); //PauseMenu is active
        Time.timeScale = 0f; //Time is frozen
        _pauseGame = true; //Game is paused
    }
*/
}