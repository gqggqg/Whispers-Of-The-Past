using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI
using UnityEngine.SceneManagement; //Scenes
using System;

public class PauseMenu : MonoBehaviour {

    public static event Action onResume;

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

    public void Resume() {
        onResume?.Invoke();
    }

    public void Settings() {
        //TODO: Implement settings menu
    }

    public void GoToMain() { //Go to start menu
        Time.timeScale = 1f; //Time is in a regular regime
        SceneManager.LoadScene(0); //Open main menu
    }
}