using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;

    public int Highscore;
    public string HighscorePlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Load Data
        LoadScore();
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public string GetPlayerName()
    {
        return PlayerName;
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScoreName;
    }

    public void SaveScore(int score, string name)
    {
        SaveData data = new SaveData();

        Highscore = score;
        HighscorePlayer = name;

        data.HighScore = score;
        data.HighScoreName = name;

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

            Highscore = data.HighScore;
            HighscorePlayer = data.HighScoreName;
        }

        
    }



}
