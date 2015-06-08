using System;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int ScoreValue;

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        this.guiText.text = String.Format("{0:00}", ScoreValue);
    }

    public void Reset()
    {
        ScoreValue = 0;
    }
}
