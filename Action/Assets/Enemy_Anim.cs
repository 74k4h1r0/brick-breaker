using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Anim : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float stopDistance;
    public float moveDistance;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < moveDistance && distance > stopDistance)
        {
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
