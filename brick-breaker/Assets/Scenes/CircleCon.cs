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
        rb.velocity = new Vector2(1, 2);

    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;

    }


    void OntriggerEnter2D(Collider2D collider2D)
    {
        string gameObjectTag = collider2D.gameObject.tag;
        Vector3 newVelocity = rb.velocity;

        if (gameObjectTag== "Item")
        {
            Destroy(collider2D.gameObject);
            newVelocity.y *= -1;
            
            GameObject obj = Instantiate(DropItem);            
            obj.transform.position = transform.position + pos;
        }
        else if (gameObjectTag== "Block")
        {
            Debug.Log("Block");
            Destroy(collider2D.gameObject);
            newVelocity.y *= -1;

        }
        else if (gameObjectTag== "wall")
        {
            newVelocity.y *= -1;

        }
        else if (gameObjectTag== "sideWall")
        {
            Debug.Log(newVelocity);
            newVelocity.x *= -1;
        }
        else if (gameObjectTag== "Player")
        {
            Debug.Log(newVelocity);
            Debug.Log(collider2D.gameObject.GetComponent<Rigidbody2D>().velocity);
            Debug.Log("");
            newVelocity.y *= -1;
        }

        rb.velocity = newVelocity.normalized * speed;
    }
}
