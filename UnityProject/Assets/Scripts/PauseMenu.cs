using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI
using UnityEngine.SceneManagement; //Scenes

public class PauseMenu : MonoBehaviour {
    private bool _pauseGame; //Check if game is paused

    [SerializeField]
    private GameObject _pauseGameMenu; //PauseMenu object

    [SerializeField]
    private Button _resume; //Button RESUME

    [SerializeField]
    private Button _settings; //Button SETTINGS

    [SerializeField]
    private Button _exit; //Button EXIT (to the main menu)

    // Start is called before the first frame update
    void Start() {
        _resume.onClick.AddListener(Resume);

        _settings.onClick.AddListener(Settings);

        _exit.onClick.AddListener(GoToMain);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Escape)) { //Using key ESC to open/close PauseMenu
            if (_pauseGame) { //If ESC pressed when game is paused the game continues
                Resume();
            } else { //If ESC pressed when game continues the game pauses  
                Pause();
            }
        }
    }

    public void Resume() {
        _pauseGameMenu.SetActive(false); //PauseMenu is inactive
        Time.timeScale = 1f; //Time is in a regular regime
        _pauseGame = false; //Game is not paused
    }

    public void Pause() {
        _pauseGameMenu.SetActive(true); //PauseMenu is active
        Time.timeScale = 0f; //Time is frozen
        _pauseGame = true; //Game is paused
    }

    public void Settings() {
        //TODO: Implement settings menu
    }

    public void GoToMain() { //Go to start menu
        Time.timeScale = 1f; //Time is in a regular regime
        SceneManager.LoadScene(0); //Open main menu
    }
}