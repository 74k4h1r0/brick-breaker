using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Con : MonoBehaviour
{
    private bool hit = false;

    public void Hit()
    {
        hit = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (hit == true)
        {
            hit = false;
        }
        
    }
}
