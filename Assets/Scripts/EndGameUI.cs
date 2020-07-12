using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class EndGameUI : SingletonBehaviour<EndGameUI> {
    public Text roundScore;
    public Text highScore;

    private Canvas _canvas;
    
    private void Start() {
        _canvas = GetComponent<Canvas>();
    }

    public void ShowEndGameUI() {
        Time.timeScale = 0;
        _canvas.enabled = true;
        roundScore.text = "Your bud grew " + ScoreCounter.I.score + "cm this time";
        highScore.text = "Your previous best bud was " + ScoreCounter.highScore + "cm";
        if (ScoreCounter.I.score > ScoreCounter.highScore) ScoreCounter.highScore = ScoreCounter.I.score;
    }
    
    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
