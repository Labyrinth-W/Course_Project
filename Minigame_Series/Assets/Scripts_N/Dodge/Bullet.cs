using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 0f;


    void Start()
    {
        // 총알 속도를 랜덤으로 조정
        bulletSpeed = Random.Range(0.15f, 0.25f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DodgeGameManager dodgeGameManager = GameObject.Find("GameManager").GetComponent<DodgeGameManager>();

        // 탄환이 충돌한게 땅이면 파괴, 플레이어면 플레이어의 체력을 깎고 파괴
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            dodgeGameManager.hp -= 0.5f;
            Destroy(gameObject);
        }

    }

}
