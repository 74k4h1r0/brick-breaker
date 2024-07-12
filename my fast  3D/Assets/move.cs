using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 2;

    float vx = 0;
    float vz = 0;
    void Start()
    {
        
    }

    void Update()
    {
        vx = Input.GetAxisRaw("Horizontal")*speed;
        vz = Input.GetAxisRaw("Vertical")*speed;
    }
    private void FixedUpdate()
    {
        this.transform.Translate(vx/50,0,vz/50);
    }

}
