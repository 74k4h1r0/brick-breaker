using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCon : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, -0.005f, 0);
    }
    void OnCollisionEnter2D(Collision2D collider2D)
    {
        if (collider2D.gameObject.tag == "Block")
        {
            Destroy(collider2D.gameObject);
        }
    }
}
