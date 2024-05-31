using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleCon : MonoBehaviour
{
    static int circleCount = 0;
    Rigidbody2D rb;
    Vector3 pos = new Vector3(0,0,0);
    


    public GameObject DropItem;
    public float speed = 1;
    void Start()
    {
        circleCount++;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 2);

    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
        if (transform.position.y <= -5.0f)
        {
            circleCount--;
            Destroy(gameObject);
            if(circleCount == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        string gameObjectTag = collider2D.gameObject.tag;
        Vector3 newVelocity = rb.velocity;
        Debug.Log(newVelocity);
        if (gameObjectTag == "Item")
        {
            Destroy(collider2D.gameObject);
            newVelocity.y *= -1;
            
            GameObject obj = Instantiate(DropItem);            
            obj.transform.position = transform.position + pos;
        }
        else if (gameObjectTag == "Block")
        {
            Debug.Log("Block");
            Destroy(collider2D.gameObject);
            newVelocity.y *= -1;

        }
        else if (gameObjectTag == "wall")
        {
            newVelocity.y *= -1;

        }
        else if (gameObjectTag == "sideWall")
        {
            Debug.Log(newVelocity);
            newVelocity.x *= -1;
        }
        else if (gameObjectTag== "Player")
        {
            newVelocity.y *= -1;
        }

        rb.velocity = newVelocity.normalized * speed;
    }

}
