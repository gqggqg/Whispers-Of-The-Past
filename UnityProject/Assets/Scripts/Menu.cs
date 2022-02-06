
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField] 
    private Button _play;

    [SerializeField] 
    private Button _settings;

    [SerializeField] 
    private Button _exit;
    
    void Start() {

        _play.onClick.AddListener(PlayPressed);

        _settings.onClick.AddListener(SettingsPressed);

        _exit.onClick.AddListener(ExitPressed);
    }

    public void PlayPressed() {
        SceneManager.LoadScene(1);
    }

    public void SettingsPressed() {
        //   menu.SetActive(false);
        //   settingsMenu.SetActive(true);
    }

    public void ExitPressed() {
        Application.Quit();
        Debug.Log("Clicked the button");
    }
}
