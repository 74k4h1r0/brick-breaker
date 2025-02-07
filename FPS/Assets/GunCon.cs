using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCon : MonoBehaviour
{
    public GameObject[] amo;
    private int number;
    void Start()
    {
        for(int i = 0; i < amo.Length; i++)
        {
            if(i == number)
            {
                amo[i].SetActive(true);
            }

            else
            {
                amo[i].SetActive(false);
            }
        }
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            number = (number + 1) % amo.Length;

            for(int i = 0; i < amo.Length; i++)
            {
                if(i == number)
                {
                    amo[i].SetActive(true);
                }

                else
                {
                    amo[i].SetActive(false);
                }
            }
        }
        
    }
}
