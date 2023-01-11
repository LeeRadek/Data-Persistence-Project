using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
   public static DataManager instance;

    public static string playerName;
    public static int playerScore;

    TMP_InputField inputField;
    GameObject field;
    
    private void Awake()
    {
        field = GameObject.Find("Input Name Field ");
        inputField = field.GetComponent<TMP_InputField>();

        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
       instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SetPlayerName()
    {
        playerName = inputField.text;
    }
}
