using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float moveSpeed;
    Transform ball;
    Rigidbody rigid;

    void Start()
    {
        ball = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody>();
        moveSpeed = 10.0f;
    }
    void Update()
    {
        //반경
        float radius = 5f;

        Vector3 posleft = new Vector3(ball.position.x, ball.position.y - 1.0f, ball.position.z);   
        Vector3 posright = new Vector3(ball.position.x, ball.position.y + 1.0f, ball.position.z);

        Collider[] colls = Physics.OverlapCapsule(posright, posleft, radius);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            WallCrashBounce(collision);
        }
    }

    void WallCrashBounce(Collision collision)
    {
        ContactPoint crashpoint = collision.GetContact(0);
        Vector3 dir = ball.position - crashpoint.point;
        rigid.AddForce((dir).normalized * 400f);
    }
}
