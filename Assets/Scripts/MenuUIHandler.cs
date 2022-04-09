using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    [SerializeField] TMP_Text highScoreText;

    private void Start()
    {
        string highScoreName = PersistenceManager.Instance.HighScoreName;
        string highScore = PersistenceManager.Instance.HighScore.ToString();

        highScoreText.text = "Best Score : " + highScoreName + " : " + highScore;
    }

    public void OnNameInputEnd()
    {
        PersistenceManager.Instance.PlayerName = playerNameInput.text;
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitButtonClick()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
