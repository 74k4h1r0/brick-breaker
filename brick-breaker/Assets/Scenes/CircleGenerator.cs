using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGenerator : MonoBehaviour
{
    public GameObject Circle;

    void Start()
    {
        Vector3 pos = new Vector3(0,0,0);
        GameObject obj = Instantiate(Circle);            
        obj.transform.position = transform.position + pos;
    }

    void Update()
    {
        
    }
}
