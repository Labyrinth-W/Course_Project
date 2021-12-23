using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    // 탄환 프리팹
    public GameObject Bullet;

    // 슈터의 위치값
    public Transform FirePos;

    // 난이도 증가 및 비중복 발사를 위해 발사 위치를 2개로 조정
    float randomPositionX = 0;
    float randomPositionX2 = 0;

    // 발사 간격
    public float fireTime = 0f;
    public float fireTimeNow = 0f;

    // 탄환 발사 간격 감소 시간 확인
    public float overTime = 0;

    // 총 생존 시간 확인
    public float totalTIme = 0;

    // 텍스트 표시를 위해 간격 감소 횟수 확인
    public float fireTimeCounter = 0;

    // 탄환 발사 가능 여부를 확인
    public bool activate;

    void Start()
    {
        activate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            overTime += Time.deltaTime;
            totalTIme += Time.deltaTime;

            fireTimeNow -= Time.deltaTime;

            // 10초마다 탄환 발사 간격이 0.1초씩 감소, 카운터를 올리고 초기화
            if (overTime >= 10)
            {
                overTime = 0;
                fireTime -= 0.1f;
                fireTimeCounter++;
            }

            // 발사 간격이 될 때마다 2개 위치에서 랜덤으로 탄환을 발사
            // 비중복을 더 섬세하게 하기 위해 두 위치의 Y좌표를 다르게 함
            if (fireTimeNow <= 0)
            {
                randomPositionX = Random.Range(-9f, 9f);
                randomPositionX2 = Random.Range(-9f, 9f);

                fireTimeNow = fireTime;
                Instantiate(Bullet, new Vector3(randomPositionX, 10, 95), FirePos.transform.rotation);
                Instantiate(Bullet, new Vector3(randomPositionX2, 20, 95), FirePos.transform.rotation);
            }
        }
    }
}
