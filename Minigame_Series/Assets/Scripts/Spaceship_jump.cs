using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_jump : MonoBehaviour
{
    // 처음 누른 곳의 위치 벡터값
    private Vector3 firstPos;
    // 나중에 누른 곳의 위치 벡터값
    private Vector3 latePos;

    // 마우스 클릭을 검사
    private bool isClick;

    // 마우스 드래그 벡터값
    private Vector3 dragVector;
    // 마우스 드래그 벡터의 방향 벡터값
    private Vector3 dragVectorDir;

    // 마우스 드래그 벡터의 세기
    private float vectorManitude;
    // 마우스 드래그 벡터의 Z축 각도
    private float currentVecZ;

    // 발사 가능 여부
    private bool canFly;

    // 이동 속도
    public float moveSpeed;
    Transform ball;
    Rigidbody rigid;

    // 방향을 표시할 조준선
    [SerializeField] private GameObject Line;

    void Start()
    {
        ball = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody>();
        moveSpeed = 10.0f;
    }

     void Update()
    {
        float radius = 5f;

        Vector3 posleft = new Vector3(ball.position.x, ball.position.y - 1.0f, ball.position.z);
        Vector3 posright = new Vector3(ball.position.x, ball.position.y + 1.0f, ball.position.z);

        Collider[] colls = Physics.OverlapCapsule(posright, posleft, radius);

        // 오른쪽 마우스를 누르는 상태일 때 클릭 상태를 활성화하고 현재 위치를 설정
        if (Input.GetMouseButtonDown(1))
        {
            firstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isClick = true;        

        }
        // 오른쪽 마우스를 떼면 클릭 상태를 비활성화하고 조준한 방향에 힘을 가함 
       else if (Input.GetMouseButtonUp(1))
        {
            Line.SetActive(false);
            isClick = false;
            if (canFly)
            {             
                rigid.AddForce((dragVectorDir).normalized * (vectorManitude * 85f));
            }
        }

        // 클릭 상태가 활성화됐을 때
        if (isClick)
        {
            // 정지
            rigid.velocity = Vector3.zero;

            latePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 드래그할 방향과 벡터값을 계산
            dragVector = (latePos - firstPos) * -1;
            vectorManitude = dragVector.magnitude;
            dragVectorDir = dragVector.normalized;

            Debug.Log(firstPos);
            Debug.Log(latePos);
            Debug.Log(dragVector);

            float tan_z = Mathf.Atan2(dragVectorDir.y, dragVectorDir.x) * Mathf.Rad2Deg;
            Debug.Log(tan_z);

            // 벡터의 세기 [ 드래그 강도 ] 가 5 이상일 때 Z축 각도를 현 각도로 설정하고 발사를 활성화
            // 아니라면 발사를 비활성화
            if(PowerCheck() && tan_z > 0)
            {
                currentVecZ = Mathf.Clamp(tan_z - 90, -80, 80);
                Line.transform.localScale = new Vector3(1, 1, 1); // 수정
                transform.rotation = Quaternion.AngleAxis(currentVecZ, Vector3.forward);
                canFly = true;
                Line.SetActive(true);
            }
            else
            {
                canFly = false;
                Line.SetActive(false);
            }
        }
    }

    private bool PowerCheck()
    {
        return vectorManitude > 5;
    }

    // 부딪힌 오브젝트가 벽이라면 WallCrashBounce를 실행
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            WallCrashBounce(collision);
        }
    }

    // ' Wall ' 태그를 갖고있는 오브젝트와 충돌했을 때 그 반대방향으로 튕겨져 나가도록 함
    // 날아가서 충돌한 방향의 반대 방향으로 힘을 가함
    void WallCrashBounce(Collision collision)
    {
        ContactPoint crashpoint = collision.GetContact(0);
        Vector3 dir = ball.position - crashpoint.point;
        rigid.AddForce((dir).normalized * 150f);
    }
}
