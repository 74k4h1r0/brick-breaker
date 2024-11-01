using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Con : MonoBehaviour
{
    private bool hit = false;
    GameObject unitychan;
    move script; 

    void Start()
    {
        unitychan = GameObject.Find("unitychan");
        script = unitychan.GetComponent<move>();
    }

    public void Hit()
    {
        hit = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (hit == true && script.Invb == false)
        {
            hit = false;
            Debug.Log("hit");
        }
        else
        {
            script.Invb = false;
            //Debug.Log("Nohit");
        }
        
    }
}
