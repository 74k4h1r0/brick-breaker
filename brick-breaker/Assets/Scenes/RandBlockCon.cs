using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandBlockCon : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Block")]
    private GameObject block;
    [SerializeField]
    private Transform rangeA;
    [SerializeField]
    private Transform rangeB;

    void Start()
    {
        for(int i = 0; i < 80; i++)
        {
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = Random.Range(rangeA.position.y, rangeB.position.y);

            Instantiate(block, new Vector3(x,y,0), block.transform.rotation);
        }
    }
}
