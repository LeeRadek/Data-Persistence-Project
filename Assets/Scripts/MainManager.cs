using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScore;
    public GameObject GameOverText;

    public MeshRenderer paddle;
    public MeshRenderer ball;
    public Material defoultMat;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

    int index = 0;
    DataManager dataManager;

    private void Awake()
    {
        BestScore.text = "Best Score: " + DataManager.playerName + " " + DataManager.bestPlayerScore;

        dataManager = FindObjectOfType<DataManager>();
        

        if (DataManager.paddleMat == null)
        {
            paddle.material = defoultMat;
        }
        else
        {
            paddle.material = DataManager.paddleMat;
        }

        if (DataManager.ballMat == null)
        {
            ball.material = defoultMat;
        }
        else
        {
            ball.material = DataManager.ballMat;
        }
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        if (m_Points > DataManager.bestPlayerScore)
        {
            DataManager.bestPlayerScore = m_Points;
            BestScore.text = "Best Score: " + DataManager.playerName + " " + DataManager.bestPlayerScore;
            BestScore = null;

            CheckScoreBoard();

            dataManager.SaveScore();

        }




    }

    void CheckScoreBoard()
    {
        bool isEqual = false;
        bool isGreater = false;
        index = 0;



        for (int i = 0; i < DataManager.m_ScoreBoard.Length - 1; i++)
        {
            if (DataManager.m_ScoreBoard[i].score == m_Points)
            {
                isEqual = true;
                print(isEqual);
            }

            if (DataManager.m_ScoreBoard[i].score < m_Points)
            {
                isGreater = true;


                index = i;

                break;
            }

        }



        if (isGreater)
        {
            for (int i = 0; i < DataManager.m_ScoreBoard.Length - 1 - index; i++)
            {
                int firstElement = DataManager.m_ScoreBoard.Length - 1 - i;
                int secondElement = DataManager.m_ScoreBoard.Length - 2 - i;

                DataManager.m_ScoreBoard[firstElement] = DataManager.last_ScoreBoard[secondElement];
                //print(i + " i");
            }

            DataManager.m_ScoreBoard[index].score = m_Points;
            DataManager.m_ScoreBoard[index].Name = DataManager.playerName;
        }

        if (isEqual)
        {
            for (int i = 0; i < DataManager.m_ScoreBoard.Length - 1 - index; i++)
            {
                int firstElement = DataManager.m_ScoreBoard.Length - 1 - i;
                int secondElement = DataManager.m_ScoreBoard.Length - 2 - i;

                DataManager.m_ScoreBoard[firstElement] = DataManager.last_ScoreBoard[secondElement];

            }
            DataManager.m_ScoreBoard[index].score = m_Points;
            DataManager.m_ScoreBoard[index].Name = DataManager.playerName;

            print(DataManager.m_ScoreBoard[0].Name);
        }

        DataManager.last_ScoreBoard = DataManager.m_ScoreBoard;

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);

    }
}
