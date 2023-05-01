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
        bestScoreText.text = GameManager.Instance.GetBestScoreMessage();
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
