using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Retry");
        Time.timeScale = 1f;
    }
}
