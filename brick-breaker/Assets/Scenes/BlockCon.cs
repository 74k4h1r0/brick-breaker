using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCon : MonoBehaviour
{

    public GameObject block;
    public GameObject Square;

    public GameObject Item;
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        for (int t = 0; t < 6; t++)
            {
                pos.x = 0;
                for (int i = 0; i < 25; i++)
                {
                    pos.x += 0.8f;
                    
                    if(Random.Range(0,10) < 8)
                    {
                        GameObject obj = Instantiate(Item);
                        
                        obj.transform.position = transform.position + pos;
                    }
                    else if(Random.Range(0,10) < 5)
                    {
                        GameObject  obj = Instantiate(block);

                        obj.transform.position = transform.position + pos;
                    }
                    else
                    {
                        GameObject obj = Instantiate(Square);

                        obj.transform.position = transform.position + pos;
                    }
                }  
                pos.y -= 0.5f;
            }
    }

    void Update()
    {
       
    }
}
