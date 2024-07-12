using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Text>().text = ScoreDirector.score.ToString();
        Debug.Log(ScoreDirector.score);
    }

    void Update()
    {
        
    }
}
