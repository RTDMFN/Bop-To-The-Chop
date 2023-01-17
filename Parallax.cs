using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length = 48.29f;
    private float startpos;
    public float parallaxEffect;

    void Start(){
        startpos = transform.position.x;
    }

    void Update(){
        // float temp = (3f * (1-parallaxEffect));
        // float dist = (3f * parallaxEffect);
        // transform.position = new Vector3(startpos + dist,transform.position.y, transform.position.z);

        // if(temp > startpos + length) startpos += length;
        // else if(temp < startpos - length) startpos -= length;
        transform.Translate(Vector3.left * Time.deltaTime * (1-parallaxEffect));

        if(transform.position.x < startpos - length) transform.position = new Vector3(startpos,transform.position.y,transform.position.z);
    }
}
