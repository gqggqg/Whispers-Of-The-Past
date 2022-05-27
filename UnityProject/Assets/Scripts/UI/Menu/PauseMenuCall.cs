using UnityEngine;

public class PauseMenuCall : MonoBehaviour {

    [SerializeField]
    private GameObject _pauseGameMenu;

    private bool _isGamePaused = false;

    private void Start() {
        PauseMenu.onResume += ChangeMenuState;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ChangeMenuState();
        }
    }

    public void ChangeMenuState() {
        _isGamePaused = !_isGamePaused;
        _pauseGameMenu.SetActive(_isGamePaused);
        Time.timeScale = _isGamePaused ? 0f : 1f;
    }
}
