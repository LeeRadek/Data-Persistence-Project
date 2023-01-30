using scoreboard;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public static string playerName;
    public static int bestPlayerScore;

    public static string bestScoreText;

    public static Material ballMat;
    public static Material paddleMat;

    public static Button padButton;
    public static Button ballButton;


    public static ScoreBoard[] m_ScoreBoard = new ScoreBoard[10];
    public static ScoreBoard[] last_ScoreBoard = new ScoreBoard[10];



    private void Awake()
    {


        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);


    }


#region SaveData
    [System.Serializable]
    public class SaveData
    {
        public ScoreBoard[] board;

        

    }


    public void SaveScore()
    {
        SaveData data = new SaveData();

        data.board = new ScoreBoard[10];
        data.board = last_ScoreBoard;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/save.json", json);

        Debug.Log(System.IO.File.Exists("/save.json"));
        print("saved");
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            last_ScoreBoard = data.board;
        }
    }
    #endregion

    #region SaveSettings
    [System.Serializable]
    public class SaveSettings
    {
        public Material padMat;
        public Material ballMat;

        public Button padButton;
        public Button ballButton;
    }

    public void SaveColor()
    {
        SaveSettings settings = new SaveSettings();

        settings.padMat = paddleMat;
        settings.ballMat = ballMat;

        settings.padButton = padButton;
        settings.ballButton = ballButton;

        string json = JsonUtility.ToJson(settings);
        File.WriteAllText(Application.persistentDataPath + "/savesettings.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savesettings.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText (path);
            SaveSettings settings = JsonUtility.FromJson<SaveSettings>(json);

            paddleMat = settings.padMat;
            ballMat = settings.ballMat;

            padButton = settings.padButton;
            ballButton = settings.ballButton;
        }

    }
    #endregion
}
