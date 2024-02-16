using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCon : MonoBehaviour
{
    public GameObject square;
    void Start()
    {
        Vector3 pos = transform.position;

        for (int i = 0; i < 32; i++)
        {
            GameObject obj = Instantiate(square);
            pos.y += 0.3f;
            obj.transform.position = transform.position + pos;
        }

    }
    void Update()
    {

    }

    void WallSet()
    {
        for(int wallcnt = 0; wallcnt < 32; wallcnt++)
        {

        }
    }
}
