using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAnimation_Planet : MonoBehaviour
{
    Vector3 pos; 

    public float delta = 1.0f; 
    public float speed = 1.5f; 

    void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        Vector3 vec = pos;

        vec.y += delta * Mathf.Sin(Time.time * speed);
    
        transform.position = vec;
    }
}
