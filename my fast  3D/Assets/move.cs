using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 movingDirection;
    public float speedMagnification;
    public Rigidbody rb;
    public Vector3 movingVelocity;

    private Animator anim = null;

    private bool jumpNow;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        movingDirection = new Vector3(x,0,z);
        movingDirection.Normalize();
        movingVelocity = movingDirection * speedMagnification;
        if (z > 0)
        {
            anim.SetBool("RUN",true);
        }
        else if (z < 0)
        {
            anim.SetBool("RUN",true);
        }
        else
        {
            anim.SetBool("RUN",false);
        }
    }

    void FixedUpdate()
    {
        if(jumpNow == true) return;
        rb.velocity = new Vector3(movingVelocity.x, rb.velocity.y, movingVelocity.z);
    }

}
