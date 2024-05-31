using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CircleGenerator : MonoBehaviour
{
    public GameObject Circle;
    public static CircleGenerator Ccon;
    
    void Start()
    {
        Vector3 pos = new Vector3(0,0,0);
        GameObject obj = Instantiate(Circle);            
        obj.transform.position = transform.position + pos;
    }

    void Update()
    {
        
    }
    public void GameOver()
    {
        GameObject search = GameObject.Find("Circle(Clone)");
        bool n = (bool)search;
        if(n == false)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
