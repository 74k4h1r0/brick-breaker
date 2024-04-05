using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCon : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 callentvelocity;
    Rigidbody2D playerrb; 

    public GameObject DropItem;
    void Start()
    {
        playerrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 2);
        callentvelocity = rb.velocity;

    }

    void Update()
    {

    }

    Vector3 pos = new Vector3(0,0,0);
    void OnCollisionEnter2D(Collision2D collider2D)
    {
        float x = Random.Range(-0.8f, 0.8f);
        float y = Random.Range(0f,1f);

        Vector2 reflect= new Vector2(x,y).normalized;
        
        if (collider2D.gameObject.tag == "Item")
        {
            Destroy(collider2D.gameObject);
            rb.velocity = new Vector2(callentvelocity.x, -callentvelocity.y);
            
            GameObject obj = Instantiate(DropItem);            
            obj.transform.position = transform.position + pos;
        }
        else if (collider2D.gameObject.tag == "Block")
        {
            Destroy(collider2D.gameObject);
            rb.velocity = new Vector2(callentvelocity.x, -callentvelocity.y);
        }
        else if (collider2D.gameObject.tag == "wall")
        {
            //callentvelocity.x += playerrb.velocity.x/2;
            rb.velocity = new Vector2(callentvelocity.x, -callentvelocity.y);
        }
        else if (collider2D.gameObject.tag == "sideWall")
        {
            rb.velocity = new Vector2(-callentvelocity.x, callentvelocity.y);
        }
        else if (collider2D.gameObject.tag == "Player")
        {
            //callentvelocity.x += playerrb.velocity.x/2;
            rb.velocity = reflect;
        }
        callentvelocity = rb.velocity;
    }
}
