using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDirector : MonoBehaviour
{
    public static int score = 0;
    GameObject ScoreText;
    void Start()
    {
        score = 0;
        ScoreText = GameObject.Find("ScoreText");
    }

    void Update()
    {
        ScoreText.GetComponent<Text>().text = score.ToString();
    }

    public void setScore(int point)
    {
        score += point;
    }

    public int getScore()
    {
        return score;
    }
}