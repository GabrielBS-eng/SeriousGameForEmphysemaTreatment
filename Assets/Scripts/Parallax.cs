using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    // Dictates how fast the parallax when the player is moved forward
    private float forwardParallaxCoef = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        parallaxEffect = 1 - parallaxEffect; //inverting the effect (not necessary, just invert the effect value in each sprite).
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x);
        float temp = (1 + forwardParallaxCoef)*cam.transform.position.x + Time.realtimeSinceStartup*parallaxEffect;

        transform.position = new Vector3(startpos - (forwardParallaxCoef)*dist - Time.realtimeSinceStartup*parallaxEffect, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
