using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardSceneManager : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
