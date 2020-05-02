using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PressController : MonoBehaviour
{
    public Animator animator;

    //public delegate void PlayerDelegate();
    //public static event PlayerDelegate OnPlayerDied;

    //for the movement forward
    public float runSpeed;
    //public float forwardMove = 0;

    public float pressForce;
    public Vector3 startPos;

    new Rigidbody2D rigidbody;

    public float vel;

    public static bool gameOver;

    public static float countDown;
    private float countDown_aux;

    public enum gameState
    {
        scene,
        beginning,
        newCicle,
        duringCicle,
        theEnd
    };

    public static gameState state;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

        countDown = float.Parse(Parameters.countDown);
        countDown_aux = countDown;

        runSpeed = 6.75f;
        rigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("forwardMove", 0.2f);
        pressForce = 4f;
        rigidbody.gravityScale = 0;
        state = gameState.scene;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == gameState.duringCicle) Fly();
    }

    //for the movement forward
    void FixedUpdate()
    {
        switch (state)
        {
            case gameState.scene:
                transform.Translate(new Vector2(animator.GetFloat("forwardMove"), 0));
                break;

            case gameState.beginning:
                ForwardMove(new Vector2(animator.GetFloat("forwardMove"), rigidbody.angularDrag*Time.fixedDeltaTime + rigidbody.velocity.y));
                if (animator.GetBool("grounded") == true) state = gameState.duringCicle;
                break;

            case gameState.duringCicle:
                rigidbody.gravityScale = 0;
                ForwardMove(new Vector2(animator.GetFloat("forwardMove"), vel));
                //if(Input.GetButtonDown("Jump")) transform.Translate(new Vector2(animator.GetFloat("forwardMove"), pressForce * Time.fixedDeltaTime));
                //if(Input.GetButtonDown("Jump")) rigidbody.MovePosition(rigidbody.position + new Vector2(0, pressForce * Time.fixedDeltaTime));
                break;

            case gameState.newCicle:
                rigidbody.gravityScale = 1;
                ForwardMove(new Vector2(animator.GetFloat("forwardMove"), rigidbody.angularDrag*Time.fixedDeltaTime + rigidbody.velocity.y));
                if (animator.GetBool("grounded") == true && !Input.GetButton("Jump")) state = gameState.duringCicle;
                break;

            case gameState.theEnd:
                //transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "DeadZone")
        {
            rigidbody.simulated = false;
            animator.SetBool("grounded", true);
            animator.SetFloat("forwardMove", 0f);
        }
    }

    void ForwardMove(Vector2 direction)
    {
        rigidbody.velocity = direction;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case ("TriggerZone"):
                ForwardMove(new Vector2(animator.GetFloat("forwardMove"), 4f));
                state = gameState.newCicle;
                rigidbody.simulated = true;
                animator.SetFloat("forwardMove", runSpeed);
                rigidbody.gravityScale = 1;
                rigidbody.angularDrag = 0.05f;
                break;

            case ("BeginningZone"):
                state = gameState.beginning;

                rigidbody.simulated = true;
                animator.SetFloat("forwardMove", 10f);
                rigidbody.gravityScale = 0.25f;
                rigidbody.angularDrag = 0.05f;
                break;

            case ("EndGame"):
                Debug.Log("cab");
                state = gameState.theEnd;
                gameOver = true;
                break;

            default:
                animator.SetFloat("forwardMove", 0);
                break;
        }
    }

    void Fly()
    {
        if(Input.GetButton("Jump"))
        {
            rigidbody.simulated = true;
            animator.SetBool("grounded", false);
            vel = 11.605f/countDown;
        }
        else
        {
            vel = 0;
        }
    }
}
