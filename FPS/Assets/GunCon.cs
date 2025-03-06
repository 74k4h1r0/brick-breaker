using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCon : MonoBehaviour
{
    public GameObject[] gunN;
    private int number;
    void Start()
    {
        for(int i = 0; i < gunN.Length; i++)
        {
            if(i == number)
            {
                gunN[i].SetActive(true);
            }

            else
            {
                gunN[i].SetActive(false);
            }
        }
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            number = (number + 1) % gunN.Length;

            for(int i = 0; i < gunN.Length; i++)
            {
                if(i == number)
                {
                    gunN[i].SetActive(true);
                }

                else
                {
                    gunN[i].SetActive(false);
                }
            }
        }
        
    }
}
