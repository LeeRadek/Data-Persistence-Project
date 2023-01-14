using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardSceneManager : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
