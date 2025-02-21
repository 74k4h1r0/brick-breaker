using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCon : MonoBehaviour
{
    public GameObject[] gunS;
    private int number;
    void Start()
    {
        for(int i = 0; i < gunS.Length; i++)
        {
            if(i == number)
            {
                gunS[i].SetActive(true);
            }

            else
            {
                gunS[i].SetActive(false);
            }
        }
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            number = (number + 1) % gunS.Length;

            for(int i = 0; i < gunS.Length; i++)
            {
                if(i == number)
                {
                    gunS[i].SetActive(true);
                }

                else
                {
                    gunS[i].SetActive(false);
                }
            }
        }
        
    }
}
