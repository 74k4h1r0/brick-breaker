using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    Vector3 movingDirection;
    public float speedMagnification;
    public Vector3 movingVelocity;
    float speed = 2.5f;

    void Start()
    {
    }
    void Update()
    {
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        if (z != 0)
        {
            transform.position += transform.forward * z ;
        }
        else
        {
            transform.position += transform.forward * z / 3;
        }
    }
}
