using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 movingDirection;
    public float speedMagnification;
    public Rigidbody rb;
    public Vector3 movingVelocity;

    private bool jumpNow;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        movingDirection = new Vector3(x,0,z);
        movingDirection.Normalize();
        movingVelocity = movingDirection * speedMagnification;
        Debug.Log(movingVelocity);
    }
    void FixedUpdate()
    {
        if(jumpNow == true) return;
        rb.velocity = new Vector3(movingVelocity.x, rb.velocity.y, movingVelocity.z);
    }

}
