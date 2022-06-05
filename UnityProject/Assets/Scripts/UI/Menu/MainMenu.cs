using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI {
    public class MainMenu : MonoBehaviour {

        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _exitButton;

        private bool _isGamePaused = false;

        private void Start() {
            _playButton.onClick.AddListener(LoadGameScene);
            _settingsButton.onClick.AddListener(LoadSettingsScreen);
            _exitButton.onClick.AddListener(QuitGame);
        }

        private void LoadGameScene() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }

        private void LoadSettingsScreen() {
            // TODO: Implement settings menu correctly
            // menu.SetActive(false);
            // settingsMenu.SetActive(true);
        }

        private void QuitGame() {
            Application.Quit();
            Debug.Log("Quit the game");
        }
    }
}
