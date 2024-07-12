using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject Circle;
    public GameObject LongPlayer;
    public GameObject Player;

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
    void OnTriggerEnter2D(Collider2D collider2D)
    {
    Vector3 pos = new Vector3(0,0.4f,0);
    Vector3 pos2 = new Vector3(0.3f,0.4f,0);

        string gameObjectTag = collider2D.gameObject.tag;
        if (gameObjectTag == "DropItem")
        {
            Destroy(collider2D.gameObject);
            if(Random.Range(0,10) < 0)
            {
                GameObject obj = Instantiate(Circle);            
                obj.transform.position = transform.position + pos;
            }
            else if(Random.Range(0,10) < 9)
            {   
                GameObject obj = Instantiate(Circle);            
                obj.transform.position = transform.position + pos;
                
                GameObject obj2 = Instantiate(Circle);            
                obj2.transform.position = transform.position + pos2;
            }
            else
            {
                GameObject obj = Instantiate(LongPlayer);            
                obj.transform.position = transform.position;
                Destroy(gameObject);
            }
        }

    }
}
