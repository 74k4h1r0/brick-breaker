using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public bool SLIDE;
    public float SLIDEbalance;

    public bool Invb = true;

    int maxHp = 80;
    int currentHp;
    public Slider hp;
    public int dec = 20;

    public GameObject GameOverPanel;
    private bool panel = false;

    public GameObject Capsule;

    CapsuleCollider slide_collider;
    
    void Start()
    {
        GameOverPanel.SetActive(false);

        transform.localScale = new Vector3(0.8f,0.8f,0.8f);

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        slide_collider = GetComponent<CapsuleCollider>();

        hp.value = 1;
        currentHp = maxHp;

        Capsule.SetActive(false);
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        if(SLIDE == false)
        {
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

    public void Dec()
    {
        currentHp = currentHp - dec;
        hp.value = (float)currentHp / (float)maxHp;
        if(currentHp <= 0)
        {
            panel = true;
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
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
        if(SLIDE == true) return;                 //RUN状態以外でスライドができないようにプログラムする
        if(Input.GetKeyDown(KeyCode.LeftShift) && anim.GetCurrentAnimatorStateInfo(0).IsName("RUN"))
        {
            Capsule.SetActive(true);
            rb.AddForce(transform.forward * SLIDEbalance, ForceMode.Impulse);
            SLIDE = true;
            anim.SetTrigger("SLIDE");
        }
    }

    void FixedUpdate()
    {
        if(SLIDE == true) return;
        if(jumpNow == true) return;
    }

    public void EndSlide()
    {
        SLIDE = false;
        Capsule.SetActive(false);
    }

}
