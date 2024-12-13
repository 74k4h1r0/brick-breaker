using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit_Con : MonoBehaviour
{
    private bool hit = false;
    GameObject unitychan;
    move script; 

    GameObject Gamedirector;
    Time_Con TimeScript;

    void Start()
    {
        unitychan = GameObject.Find("unitychan");
        script = unitychan.GetComponent<move>();
        Gamedirector = GameObject.Find("Gamedirector");
        TimeScript = Gamedirector.GetComponent<Time_Con>();
    }

    public void Hit()
    {
        hit = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (hit == true && script.Invb == false)
        {
            script.Dec();
            hit = false;
            Debug.Log("hit");
        }
        else if(hit == true && script.SLIDE == true)
        {
            script.Invb = false;
            TimeScript.time = TimeScript.time - 5f;
            //Debug.Log("Nohit");
        }
        else
        {
            script.Invb = false;
        }
    }

}
