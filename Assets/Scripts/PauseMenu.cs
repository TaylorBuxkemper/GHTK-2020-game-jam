using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class PauseMenu : MonoBehaviour {
    public Text currentScoreText;
    public Text highScoreText;
    
    private Canvas _canvas;

    void Start() {
        _canvas = GetComponent<Canvas>();
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            ShowPauseMenu();
        }
    }

    void ShowPauseMenu() {
        currentScoreText.text = "Current Score: " + ScoreCounter.I.score;
        highScoreText.text = "High Score: " + ScoreCounter.highScore;
        Time.timeScale = 0f;
        _canvas.enabled = true;
    }

    public void HidePauseMenu() {
        Time.timeScale = 1f;
        _canvas.enabled = false;
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
