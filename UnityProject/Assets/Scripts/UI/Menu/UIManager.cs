using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

namespace Game.UI {

    public class UIManager : MonoBehaviour {

        [SerializeField]
        private GameObject _menu;

        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private Button _resumeButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _exitButton;


        [NonSerialized]
        private bool _isGame;

        [NonSerialized]
        private bool _isPause;


        private static UIManager _instance;


        private void Awake() {
            if (_instance == null) {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            } else {
                Destroy(this);
            }
        }

        private void Start() {
            _playButton.onClick.AddListener(LoadGameScene);
            _resumeButton.onClick.AddListener(ResumeGame);
            _settingsButton.onClick.AddListener(LoadSettingsScreen);
            _exitButton.onClick.AddListener(ExitHandler);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                SetMenuActive(!_isPause);
            }
        }

        private void ExitHandler() {
            if (_isGame) {
                LoadMenuScene();
                return;
            }

            Application.Quit();
            Debug.Log("Quit the game");
        }

        private void ResumeGame() {
            SetMenuActive(false);
        }

        private void LoadSettingsScreen() {
            // TODO: Implement settings menu
        }

        private void SetMenuActive(bool value) {
            Time.timeScale = value ? 0f : 1f;
            _menu.SetActive(value);
            _isPause = value;
        }

        private void UpdateButtons() {
            _playButton.gameObject.SetActive(!_isGame);
            _resumeButton.gameObject.SetActive(_isGame);
        }

        private void LoadGameScene() {
            LoadScene(isGameScene: true);
        }

        private void LoadMenuScene() {
            LoadScene(isGameScene: false);
        }

        private void LoadScene(bool isGameScene) {
            SceneManager.LoadScene(isGameScene ? 1 : 0);
            _isGame = isGameScene;
            UpdateButtons();
            SetMenuActive(!isGameScene);
        }
    }
}
