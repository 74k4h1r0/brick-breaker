using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPlayerCon : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject Circle;
    public GameObject LongPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
    }    
    void Update()
    {
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < 9.5f)
        {
            rb.velocity = new Vector2(5, 0);
        }
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > -9.5f)
        {
            rb.velocity = new Vector2(-5, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);      
        }
    }
}
