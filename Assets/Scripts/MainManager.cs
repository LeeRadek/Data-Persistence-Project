using System.Collections;
using System.Collections.Generic;
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
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    int loops = 0;

    private void Awake()
    {
        BestScore.text = "Best Score: " + DataManager.playerName + " " + DataManager.bestPlayerScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
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
        if(m_Points > DataManager.bestPlayerScore)
        {
            DataManager.bestPlayerScore = m_Points;
            BestScore.text = "Best Score: " + DataManager.playerName + " " + DataManager.bestPlayerScore;
            BestScore = null;

            CheckBoard();
            //SetBoard();
            
            
        }
        
        


    }

    void CheckBoard()
    {
        bool isEqual = false;
        bool isGreater = false;
        loops = 0;
        
        

        for (int i = 0; i < DataManager.m_ScoreBoard.Length - 1; i++)
        {
            if(DataManager.m_ScoreBoard[i].score == m_Points)
            {
                isEqual = true;
            }

            if(DataManager.m_ScoreBoard[i].score < m_Points)
            {
                isGreater = true;


                loops += 1;
                
                break;
            }
            
        }

        for(int i = 0; i < loops; i++)
        {

            print("loops" + i);
            if (isEqual)
            {
                
                print("is equlas");
            }

            if (isGreater)
            {

                if(DataManager.m_ScoreBoard[i].score < m_Points)
                {
                    DataManager.m_ScoreBoard[loops].score = m_Points;
                    DataManager.m_ScoreBoard[loops].Name = DataManager.playerName; //replace old score to new score

                    m_Points = 0;
                }
                

                DataManager.m_ScoreBoard[i + 1].score = DataManager.last_ScoreBoard[i].score; //move scores down
                DataManager.m_ScoreBoard[i + 1].Name = DataManager.last_ScoreBoard[i].Name;

                
            }
            
            
        }

        

        DataManager.last_ScoreBoard = DataManager.m_ScoreBoard; //save array

    }

    void SetBoard()
    {
        
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        
    }
}
