using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PressController : MonoBehaviour
{
    public Animator animator;

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;

    public float pressForce = 10;
    public Vector3 startPos;

    public float flyForce = 5f;

    Rigidbody2D rigidbody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
//        downRotation = Quaternion.Euler(0, 0, -90);
//        forwardRotation = Quaternion.Euler(0, 0, 35);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Collider2D col;

       // if(col.gameObject.tag == "DeadZone")
       // {
       //     rigidbody.simulated = false;
       //     animator.SetBool("grounded", true);
       // }
        Fly(); 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "DeadZone")
        {
            rigidbody.simulated = false;
            animator.SetBool("grounded", true);
            //OnPlayerDied(); //event sent to GameManager
        }
//        else
//        {
//            rigidbody.simulated = true;
//            animator.SetBool("grounded", false);
//        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "TriggerZone")
        {
            animator.SetBool("grounded", true);
        }
//        else
//        {
//            animator.SetBool("grounded", false);
//        }
    }

    void Fly()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigidbody.simulated = true;
            animator.SetBool("grounded", false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, flyForce), ForceMode2D.Impulse);
        }
    }
}
