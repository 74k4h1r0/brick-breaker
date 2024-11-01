using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 movingDirection;
    public float speedMagnification;
    public Rigidbody rb;
    public Vector3 movingVelocity;

    private Animator anim = null;

    float speed = 2.5f;
    float angleSpeed = 200;

    private bool jumpNow;
    public float jumpPower;

    private bool SLIDE;
    public float SLIDEbalance;

    public bool Invb = true;

    CapsuleCollider slide_collider;
    
    void Start()
    {
        transform.localScale = new Vector3(0.8f,0.8f,0.8f);

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        slide_collider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        if (z > 0)
        {
            transform.position += transform.forward * z;
            Vector3 localScale = transform.localScale;
            localScale.z = 0.8f;
            transform.localScale = localScale;
            anim.SetBool("RUN",true);
            SLIDE = false;
            transform.Rotate(Vector3.up * x);

        }
        else if(z < 0)
        {
            transform.position += transform.forward * z;
            Vector3 localScale = transform.localScale;
            localScale.z = -0.8f;
            transform.localScale = localScale;
            anim.SetBool("RUN",true);
            SLIDE = false;
            transform.Rotate(Vector3.up * x);
        }
        else
        {
            transform.position += transform.forward * z / 3;
            anim.SetBool("RUN",false);
            transform.Rotate(Vector3.up * x);

        }

        Slide();
        Jump();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(jumpNow == true)
        {
            if(other.gameObject.CompareTag("Ground"))
            {
                jumpNow = false;
            }
        }
    }

    void Jump()
    {
        if(jumpNow == true) return;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            jumpNow = true;
            anim.SetTrigger("jumpNow");
        }
    }

    void Slide()
    {
        if(SLIDE == true) return;
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            //slide_collider.enabled = false;
            //Invb = true;
            rb.AddForce(transform.position * SLIDEbalance, ForceMode.Impulse);
            SLIDE = true;
            anim.SetTrigger("SLIDE");
        }
    }

    void FixedUpdate()
    {
        if(SLIDE == true) return;
        if(jumpNow == true) return;
    }

}
