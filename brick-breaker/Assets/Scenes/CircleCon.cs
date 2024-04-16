using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCon : MonoBehaviour
{
    Rigidbody2D rb;
    Rigidbody2D playerRb; 
    Vector3 pos = new Vector3(0,0,0);



    public GameObject DropItem;
    public float speed = 1;
    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 2);

    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;

    }


    void OnCollisionEnter2D(Collision2D collider2D)
    {
        string gameObjectTag = collider2D.gameObject.tag;
        Vector3 newVelocity = rb.velocity;

        if (gameObjectTag== "Item")
        {
            Destroy(collider2D.gameObject);
            newVelocity = collider2D.relativeVelocity;
            newVelocity.x *= -1;
            
            GameObject obj = Instantiate(DropItem);            
            obj.transform.position = transform.position + pos;
        }
        else if (gameObjectTag== "Block")
        {
            Debug.Log("Block");
            Destroy(collider2D.gameObject);
            // rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            newVelocity= collider2D.relativeVelocity;
            newVelocity.x *= -1;

        }
        else if (gameObjectTag== "wall")
        {
            newVelocity = collider2D.relativeVelocity;
            newVelocity.x *= -1;

        }
        else if (gameObjectTag== "sideWall")
        {
            //rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            newVelocity = collider2D.relativeVelocity;
            newVelocity.y *= -1;

        }
        else if (gameObjectTag== "Player")
        {
            float x = Random.Range(-0.8f, 0.8f);
            float y = Random.Range(0f,1f);

            Vector2 reflect= new Vector2(x,y).normalized;
        
            newVelocity= reflect;
        }

        rb.velocity = newVelocity.normalized * speed;
    }
}
