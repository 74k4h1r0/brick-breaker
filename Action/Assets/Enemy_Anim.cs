using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy_Anim : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float stopDistance;
    public float moveDistance;
    public float attackDistance;
    public float friendlyDistance;

    private Animator e_anim = null;

    GameObject Gamedirector;
    Time_Con script;

    void Start()
    {
        e_anim = GetComponent<Animator>();
        Gamedirector = GameObject.Find("Gamedirector");
        script = Gamedirector.GetComponent<Time_Con>();
    }

    void Update()
    {
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < friendlyDistance && distance > attackDistance)
        {
            e_anim.SetBool("Basic Attack", true);
        }
        else if (distance < moveDistance && distance > stopDistance)
        {
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            e_anim.SetBool("Basic Attack",false);
            e_anim.SetBool("Walk",true);
            script.TimerStart = 0;
        }
        else
        {
            e_anim.SetBool("Basic Attack",false);
            e_anim.SetBool("Walk",false);
        }
    }
}
