using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time_Con : MonoBehaviour
{
    GameObject timerText;
    float time = 60.0f;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
    }
}
