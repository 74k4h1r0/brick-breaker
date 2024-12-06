using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Time_Con : MonoBehaviour
{
    GameObject timerText;
    float time = 10.0f;

    public GameObject GameClearPanel;
    private bool panel2 = false;

    void Start()
    {
        GameClearPanel.SetActive(false);
        this.timerText = GameObject.Find("Time");
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        GC();
    }

    private void GC()
    {
        if(time <= 0f)
        {
            panel2 = true;
            GameClearPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
