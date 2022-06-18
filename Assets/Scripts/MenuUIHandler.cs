using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    // public TextMeshProUGUI inputText;
    public TMP_InputField userInputField;

    public GameObject messageText;

    public TMP_Text bestScore;

    private string _playerName;
    private int _maxScore;

    private void Start()
    {
        UpdateBestScore();
    }

    public void StartNew()
    {
        _playerName = userInputField.text;
        GameManager.Instance.playerName = _playerName;
        
        if (_playerName.Length != 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            StartCoroutine(PlayerMessage());
        }
    }
    
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        
        GameManager.Instance.SaveScore(); 
    }

    IEnumerator PlayerMessage()
    {
        messageText.SetActive(true);
        yield return new WaitForSeconds(1f);
        messageText.SetActive(false);
    }

    public void UpdateBestScore()
    {
        bestScore.text = "Best score: \t" + GameManager.Instance.bestPlayer + " : " + GameManager.Instance.maxScore;
        GameManager.Instance.ResetScore();
    }

}
