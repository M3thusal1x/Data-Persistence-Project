using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public string HighScoreName;
    public int HighScore;

    // Implemented as singleton
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public string LastPlayer;
        public string HighScoreName;
        public int HighScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.LastPlayer = PlayerName;
        data.HighScoreName = HighScoreName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";

        File.WriteAllText(path, json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.LastPlayer;
            HighScoreName = data.HighScoreName;
            HighScore = data.HighScore;
        }
    }

    public void UpdateData(int score)
    {
        if (IsNewHighScore(score))
        {
            SetNewHighScore(PlayerName, score);
            Save();
        }
    }

    private bool IsNewHighScore(int score)
    {
        return score > HighScore;
    }

    private void SetNewHighScore(string playerName, int score)
    {
        HighScoreName = playerName;
        HighScore = score;
    }
}
