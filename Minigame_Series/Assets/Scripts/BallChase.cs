using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChase : MonoBehaviour
{
    static public BallChase instance;

    public GameObject target; // 카메라가 따라갈 대상
    public float moveSpeed; // 카메라의 이동속도
    private Vector3 targetPosition; // 추적 대상의 현재 위치 

    public BoxCollider2D bound;

    private Vector3 minBound;
    private Vector3 maxBound;

    // 박스 콜라이더 영역의 최소 최대 x , y , z 값

    private float halfWidth;
    private float halfHeight;

    // 카메라의 반너비와 반높이 값을 지닐 변수

    private Camera theCamera;

    // 카메라의 반높이값을 구할 속성을 이용하기 위한 변수

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        theCamera = GetComponent<Camera>();
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void Update()
    {
        if (target.gameObject != null)
        {
            // 타겟의 위치를 설정
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            // 1초에 movespeed 만큼 이동
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);  

            // 반너비 반높이에 따라 카메라의 x값과 y값을 조정
            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            // 카메라 위치를
            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
        }
    }

    //  카메라의 범위가 지정한 범위 밖으로 벗어나려고 할 때 범위 밖이 보이지 않도록 하는 함수
    public void SetBound(BoxCollider2D newBound)
    {
        bound = newBound;
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }
}
