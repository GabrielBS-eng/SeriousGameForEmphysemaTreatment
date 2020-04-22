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
<<<<<<< HEAD
=======
        //Collider2D col;

>>>>>>> 7769130025c5b9ca1b54fa285eed53054f961d2a
       // if(col.gameObject.tag == "DeadZone")
       // {
       //     rigidbody.simulated = false;
       //     animator.SetBool("grounded", true);
       // }
        Fly(); 
    }

<<<<<<< HEAD
    //for the movement forward
    void FixedUpdate()
    {
        //ForwardMove(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        ForwardMove(new Vector2(animator.GetFloat("forwardMove"), rigidbody.angularDrag*Time.fixedDeltaTime + rigidbody.velocity.y));
    }

=======
>>>>>>> 7769130025c5b9ca1b54fa285eed53054f961d2a
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

<<<<<<< HEAD
    void ForwardMove(Vector2 direction)
    {
        rigidbody.velocity = direction;
    }

=======
>>>>>>> 7769130025c5b9ca1b54fa285eed53054f961d2a
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "TriggerZone")
        {
<<<<<<< HEAD
            animator.SetFloat("forwardMove", runSpeed);
        }
        else
        {
            animator.SetFloat("forwardMove",0f);
        }
=======
            animator.SetBool("grounded", true);
        }
//        else
//        {
//            animator.SetBool("grounded", false);
//        }
>>>>>>> 7769130025c5b9ca1b54fa285eed53054f961d2a
    }

    void Fly()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigidbody.simulated = true;
            animator.SetBool("grounded", false);
<<<<<<< HEAD
            rigidbody.AddForce(new Vector2(0f, flyForce), ForceMode2D.Impulse);
=======
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, flyForce), ForceMode2D.Impulse);
>>>>>>> 7769130025c5b9ca1b54fa285eed53054f961d2a
        }
    }
}
