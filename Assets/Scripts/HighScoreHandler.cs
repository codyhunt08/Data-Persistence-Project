using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScoreHandler : MonoBehaviour
{
    public static HighScoreHandler Instance;

    public string highScoreName;
    public int highScore;
    public string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void ResetHighScore()
    {
        highScore = 0;
        highScoreName = "Name";
        SaveScore(highScoreName, highScore);
    }

    [System.Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void SaveScore(string s, int score)
    {
        SaveData data = new SaveData();
        data.highScore = score;
        highScore = score;
        highScoreName = s;
        data.highScoreName = s;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }
}
