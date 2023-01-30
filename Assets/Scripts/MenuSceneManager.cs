using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    object field;
    TMP_InputField inputField;
    public TMP_Text bestScoreText;
    DataManager dataManager;


    private void Awake()
    {
        
        NameField();
        ScoreText();

        dataManager = FindObjectOfType<DataManager>();
        dataManager.LoadScore();
        dataManager.LoadColor();
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
        if (DataManager.last_ScoreBoard[0].score == 0)
        {
            bestScoreText.text = "No Best Score Yet";
        }
        else if (DataManager.last_ScoreBoard[0].score > 0)
        {
            bestScoreText.text = "Best Score: " + DataManager.last_ScoreBoard[0].Name + " " +
                DataManager.last_ScoreBoard[0].score;
        }
    }

    public void SetPlayerNamer()
    {
        if (DataManager.playerName != inputField.text)
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

    public void LoadSettingScene()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void EndEnterName()
    {
        DataManager.bestPlayerScore = 0; //chcek if ther is bug
    }
}
