using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleCon : MonoBehaviour
{
    static int circleCount = 0;
    Rigidbody2D rb;
    Vector3 pos = new Vector3(0,0,0);

    ScoreDirector scorecon;
    BlockCon blockCon;

    public GameObject DropItem;
    public float speed = 1;

    bool bonusPT = false;
    void Start()
    {
        circleCount++;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 2);
        scorecon = GameObject.Find("ScoreDirector").GetComponent<ScoreDirector>();
        blockCon = GameObject.Find("BlockGenerator").GetComponent<BlockCon>();
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
                    
        if(blockCon.ClearTerms == 0)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Vector3 ballPos = transform.position;
        Vector3 targetPos = collider2D.transform.position;

        string gameObjectTag = collider2D.gameObject.tag;
        Vector3 newVelocity = rb.velocity;
        if (gameObjectTag == "Item")
        {
            Destroy(collider2D.gameObject);
            newVelocity.y *= -1;
            
            if (bonusPT)
            {
                scorecon.setScore(40);
            }
            else
            {
                scorecon.setScore(20);
            }

            bonusPT = true;
            
            GameObject obj = Instantiate(DropItem);            
            obj.transform.position = transform.position + pos;

            blockCon.ClearTerms--;
        }
        else if (gameObjectTag == "Block")
        {
            float directionX = (ballPos.x - targetPos.x);
            Debug.Log(directionX);

            if(directionX <= -0.4 ||directionX >= 0.4 )
            {
                newVelocity.x *= -1;
            }
            else
            {
                newVelocity.y *= -1; 
            }
            Destroy(collider2D.gameObject);
            if (bonusPT)
            {
                scorecon.setScore(40);
            }
            else
            {
                scorecon.setScore(20);
            }

            bonusPT = true;

            blockCon.ClearTerms--;

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
            Vector3 direction = (ballPos - targetPos).normalized;
            newVelocity = direction * speed;
            newVelocity.x *= -1;

            bonusPT = false;
        }
        Debug.Log(blockCon.ClearTerms);

        rb.velocity = newVelocity.normalized * speed;
    }

}
