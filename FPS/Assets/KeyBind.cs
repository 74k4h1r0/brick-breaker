using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBind : MonoBehaviour
{
    Rigidbody rb;
    private float distance;
    private bool isGround;
    private float Dashspeed;
    private float Defaspeed;

    public List<GunCon> guns = new List<GunCon>();

    float x, z;
    float speed = 3.0f;

    public GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;
    
    bool cursorLock = true;

    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
        rb = GetComponent<Rigidbody>();
        distance = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        //Updateの中で作成した関数を呼ぶ
        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;

        RaycastHit hit;

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        isGround = Physics.Raycast(ray, out hit, distance);
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

        Dashspeed = 4.5f;
        Defaspeed = 3.0f;

        UpdateCursorLock();
        keyBind();
    }

    void keyBind()
    {
        Vector3 yspeed = new Vector3 (0f,rb.velocity.y,0f);

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (z > 0) 
        {
            rb.velocity = transform.forward * speed + yspeed;
        }
        if (z < 0)
        {
            rb.velocity = -transform.forward * speed + yspeed;
        }


        if (x > 0)
        {
            rb.velocity = transform.right * speed + yspeed;
        }
        if (x < 0)
        {
            rb.velocity = -transform.right * speed + yspeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGround)
            {
                rb.AddForce(transform.up * jumpPower);
            }
            Debug.Log(isGround);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = Dashspeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = Defaspeed;
        }
    }

    public void UpdateCursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if(Input.GetMouseButton(0))
        {
            cursorLock = true;
        }


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX,minX,maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }


}