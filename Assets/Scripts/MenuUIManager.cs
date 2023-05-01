using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField playerName;

    void Start()
    {
        if (GameManager.Instance.bestScore != null)
        {
            float score = GameManager.Instance.bestScore.score;
            string player = GameManager.Instance.bestScore.player;

            bestScoreText.text = $"Best Score : {player} : {score.ToString()}";
        }
        else
        {
            bestScoreText.text = "No best score yet";
        }
    }

    public void StartGame()
    {
        GameManager.Instance.currentPlayer = playerName.text;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
