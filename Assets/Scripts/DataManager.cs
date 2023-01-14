using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class DataManager : MonoBehaviour
{
   public static DataManager instance;

    public static string playerName;
    public static int bestPlayerScore;

    public static string bestScoreText;

    public static Dictionary<int, string> ScoreBoardMap = new Dictionary<int, string>(10);
    
    
    
    
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



    [System.Serializable]
    public class SaveData
    {
        // here only variable wicht i want to save
        
        
    }

    
}
