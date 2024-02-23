using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCon : MonoBehaviour
{

    public GameObject block;
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        for (int i = 0; i < 25; i++)
        {
            GameObject obj = Instantiate(block);
            pos.x += 0.8f;
            obj.transform.position = transform.position + pos;
        }
    }

    void Update()
    {
       
    }
}
