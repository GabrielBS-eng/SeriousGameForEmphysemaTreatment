using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PressController : MonoBehaviour
{
    public Animator animator;

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;

    //for the movement forward
    public float runSpeed = 5f;
    //public float forwardMove = 0;

    public float pressForce = 10f;
    public Vector3 startPos;

    public float flyForce = 5f;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("forwardMove", 0f);
    }

    // Update is called once per frame
    void Update()
    {
       // if(col.gameObject.tag == "DeadZone")
       // {
       //     rigidbody.simulated = false;
       //     animator.SetBool("grounded", true);
       // }
        Fly(); 
    }

    //for the movement forward
    void FixedUpdate()
    {
        //ForwardMove(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        ForwardMove(new Vector2(animator.GetFloat("forwardMove"), rigidbody.angularDrag*Time.fixedDeltaTime + rigidbody.velocity.y));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "DeadZone")
        {
            rigidbody.simulated = false;
            animator.SetBool("grounded", true);
            animator.SetFloat("forwardMove", 0f);
            //OnPlayerDied(); //event sent to GameManager
        }
//        else
//        {
//            rigidbody.simulated = true;
//            animator.SetBool("grounded", false);
//        }
    }

    void ForwardMove(Vector2 direction)
    {
        rigidbody.velocity = direction;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "TriggerZone")
        {
            animator.SetFloat("forwardMove", runSpeed);
        }
        else
        {
            animator.SetFloat("forwardMove",0f);
        }
    }

    void Fly()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigidbody.simulated = true;
            animator.SetBool("grounded", false);
            rigidbody.AddForce(new Vector2(0f, flyForce), ForceMode2D.Impulse);
        }
    }
}
