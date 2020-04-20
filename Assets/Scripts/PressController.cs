using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PressController : MonoBehaviour
{
    public float pressForce = 10;
    public Vector3 startPos;

    public float flyForce = 5f;

    Rigidbody2D rigidbody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    // Start is called before the first frame update
    void Start()
    {
//        rigidbody = GetComponent<Rigidbody2D>();
//        downRotation = Quaternion.Euler(0, 0, -90);
//        forwardRotation = Quaternion.Euler(0, 0, 35);
        
    }

    // Update is called once per frame
    void Update()
    {
        Fly(); 
    }

    void OnTriggerEnter2D(Collider2D col)
    {

    }

    void Fly()
    {
        if(Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, flyForce), ForceMode2D.Impulse);
        }
    }
}
