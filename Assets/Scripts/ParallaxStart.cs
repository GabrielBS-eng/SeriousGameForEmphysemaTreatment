using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxStart : MonoBehaviour
{
    private float length, startpos;
    public float parallaxEffect;

    private bool once;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = new Vector2(-39f + length,2.85f);
        startpos = transform.position.x;
        parallaxEffect = 1 - parallaxEffect; //inverting the effect (not necessary, just invert the effect value in each sprite).

        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        //float temp = Time.realtimeSinceStartup*parallaxEffect;

        //if (temp > startpos + length) startpos += length;
        //else if (temp < startpos - length) startpos -= length;
        if(player.activeSelf)
        {
            //to execute only once
            if (once)
            {
                transform.position = new Vector3(transform.position.x - 2 * length, transform.position.y, transform.position.z);
                once = false;
            }
        }
        else
        {
            transform.position = new Vector3(startpos - Time.realtimeSinceStartup*parallaxEffect, transform.position.y, transform.position.z);
        }
    }
}
