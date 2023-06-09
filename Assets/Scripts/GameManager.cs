using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string currentPlayer;

    public BestScore bestScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadBestScore();
    }

    void Start()
    {
        if (bestScore == null)
        {
            bestScore = new BestScore("", 0);
        }
    }

    public void SaveBestScore(float score)
    {
        BestScore newBestScore = new BestScore(currentPlayer, score);
        this.bestScore = newBestScore;
        string json = JsonUtility.ToJson(bestScore);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore data = JsonUtility.FromJson<BestScore>(json);
            this.bestScore = data;
        }
    }

    public string GetBestScoreMessage()
    {
        if (bestScore == null || bestScore.score == 0)
        {
            return "No best score yet";
        }

        return $"Best Score : {bestScore.player} : {bestScore.score.ToString()}";
    }

    public class BestScore
    {
        public string player;
        public float score;

        public BestScore(string player, float score)
        {
            this.player = player;
            this.score = score;
        }
    }
}
