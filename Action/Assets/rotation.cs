using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public GameObject playerObj;
    private Vector3 playerPos;
    float angleSpeed = 200;


    void Start()
    {
        playerObj = GameObject.Find("unitychan");
        playerPos = playerObj.transform.position;
    }

    void LateUpdate()
    {
        transform.position += playerObj.transform.position - playerPos;
        playerPos = playerObj.transform.position;
        
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
        transform.RotateAround(playerObj.transform.position, Vector3.up, x);
    }
}
