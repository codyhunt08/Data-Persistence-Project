using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public string playerName;
    public Text highScoreText;

    private void Start()
    {
        HighScoreHandler.Instance.playerName = "Name";
        highScoreText.text = $"High Score\n{HighScoreHandler.Instance.highScoreName}: {HighScoreHandler.Instance.highScore}";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void SetPlayerName(string s)
    {
        HighScoreHandler.Instance.playerName = s;
    }

    public void ResetHighScore()
    {
        HighScoreHandler.Instance.ResetHighScore();
        highScoreText.text = $"High Score\n{HighScoreHandler.Instance.highScoreName}: {HighScoreHandler.Instance.highScore}";
    }
}
