using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public GameObject playerObj;
    private Vector3 offset;
    float angleSpeed = 200;


    void Start()
    {
        playerObj = GameObject.Find("unitychan");
        offset = transform.position - playerObj.transform.position;
    }

    void LateUpdate()
    {
        transform.position = playerObj.transform.position + offset;
        
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
        transform.RotateAround(playerObj.transform.position, Vector3.up, x);
    }
}
