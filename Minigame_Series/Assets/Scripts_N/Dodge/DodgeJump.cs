using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeJump : MonoBehaviour
{

    public float moveSpeed;
    public float jumpPower;

    Rigidbody rigid;

    bool jump = true;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {     
        Move();       

        Jump();
    }

    void Move()
    {
        // 좌우로만 움직이기 때문에 X값만 조절
        float horizontal = Input.GetAxis("Horizontal");
 
        transform.Translate(new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime);
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 점프가 가능한 상태에서 점프했다면 점프한 동안은 다시 점프가 불가능
            if (jump)
            {
                jump = false;
                rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
            else return;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 지면과 충돌했을 경우 점프 가능
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }
}
