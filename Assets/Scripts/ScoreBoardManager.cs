using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardManager : MonoBehaviour
{
    public List<TMP_Text> texts = new List<TMP_Text>();
    GameObject g;
    void Awake()
    {
        g = GameObject.Find("Score 1");
        texts.Add(g.GetComponent<TMP_Text>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
