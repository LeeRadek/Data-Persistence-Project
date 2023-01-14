using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class MenuSceneManager : MonoBehaviour
{
    object field;
    TMP_InputField inputField;
    public TMP_Text bestScoreText;
    
    
    
    private void Awake()
    {

        NameField();
        ScoreText();

    }

    void NameField()
    {
        field = FindObjectOfType<TMP_InputField>();
        inputField = field as TMP_InputField;
        inputField.text = DataManager.playerName;
    }

    void ScoreText()
    {
        bestScoreText = GameObject.Find("Best Score Text").GetComponent<TMP_Text>();
        if (bestScoreText.text == "No Score")
        {
            bestScoreText.text = "No Best Score Yet";
        }
        else if(bestScoreText.text != "No Score")
        {
            bestScoreText.text = DataManager.playerName; //change when add filtering best player code
        }
    }

    public void SetPlayerNamer()
    {
        if(DataManager.playerName != inputField.text)
        {
            DataManager.playerName = inputField.text;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }


    public void LoadScoreBoard()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
