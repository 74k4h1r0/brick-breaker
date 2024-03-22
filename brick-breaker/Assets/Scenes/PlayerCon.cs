using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject Circle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
    }    
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);      
        }
    }
    Vector3 pos = new Vector3(0,0,0);
    void OnCollisionEnter2D(Collision2D Collider2D)
    {
        if(Collider2D.gameObject.tag == "DropItem")
        {
            Destroy(Collider2D.gameObject);

            GameObject obj = Instantiate(Circle);            
            obj.transform.position = transform.position + pos;
        }
    }
}
