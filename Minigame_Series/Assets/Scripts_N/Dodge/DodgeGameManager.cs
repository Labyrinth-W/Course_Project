using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DodgeGameManager : MonoBehaviour
{
    public GameObject Clocking;

    // 맨 위부터 체력, 생존 시간, 간격 감소 시간, 이벤트 ( 미구현 ) 시간 표시
    public Text HpText;
    public float hp = 3;

    public Text SurvivatlTimeText;
    public Text ShootingTimeText;
    public Text EventText;

    // 게임오버 시 최종 생존 시간
    public Text sTimeResult;
    int survivalTimeResult;

    // 생존 시간 중에서 최고 생존 시간
    public Text SurvivalTimeResultLongest;
    int survivalTimeResultLongest = 0;

    // 게임 오버 창
    public GameObject GameOver;

    // 시작 버튼 창
    public GameObject StartButton;

    // 카운트다운 오브젝트
    public Text Counter;
    float counterTime = 4;

    // 게임 시작 확인
    bool start;

    // 카운트다운 시작 확인
    bool startcounter = false;

    void Start()
    {
        Time.timeScale = 0;
        start = false;

        StartButton.SetActive(true);
    }

    void Update()
    {
        BulletShooter bulletShooter = GameObject.Find("BulletShooter").GetComponent<BulletShooter>();

        if (startcounter)
        {
            counterTime -= Time.deltaTime;
            Counter.text = "" + (int)counterTime;

            if (counterTime <= 0)
            {
                GameStart();
            }
        }

        if (start)
        {        
            HpText.text = "남은 체력 : " + (int)hp + " HP";
            SurvivatlTimeText.text = "생존 시간 : " + (int)bulletShooter.totalTIme + " 초";
            ShootingTimeText.text = "발사 간격 감소 : - " + (bulletShooter.fireTimeCounter * 0.1);

            // 체력이 0이 되면 게임오버 함수 호출
            if (hp <= 0)
            {
                    GameOverScreen();
            }
        }
    }

    // 씬 [ 게임 ] 재시작
    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameStartCount()
    {
        Time.timeScale = 1;
        Counter.gameObject.SetActive(true);
        StartButton.SetActive(false);
        startcounter = true;
    }

    public void GameStart()
    {
        BulletShooter bulletShooter = GameObject.Find("BulletShooter").GetComponent<BulletShooter>();

        start = true;
        startcounter = false;
        Counter.gameObject.SetActive(false);
        Clocking.SetActive(false);

        // 탄환 발사 시작
        bulletShooter.activate = true;
    }

    public void GameOverScreen()
    {
        BulletShooter bulletShooter = GameObject.Find("BulletShooter").GetComponent<BulletShooter>();

        // 게임을 정지시키고 최종 생존 시간 계산
        Time.timeScale = 0;
        GameOver.SetActive(true);
        survivalTimeResult = (int)bulletShooter.totalTIme;

        // 제일 최근의 최고 생존 시간 로드
        Load();

        // 최종 생존 시간이 최고 생존 시간보다 높을 경우 갱신, 후 저장
        if (survivalTimeResult > survivalTimeResultLongest)
        {
            survivalTimeResultLongest = survivalTimeResult;
        }

        Save();

        sTimeResult.text = "최종 생존 시간 : " + survivalTimeResult + " 초";
        SurvivalTimeResultLongest.text = "최고 생존 시간 : " + survivalTimeResultLongest + " 초";
    }

    public void Save()
    {
        // 최종 생존 시간 값과 텍스트를 PlayerPrefs에 저장
        PlayerPrefs.SetString("Time", SurvivalTimeResultLongest.text);
        PlayerPrefs.SetInt("TimeR", survivalTimeResultLongest);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        // Time이라는 Key [ 저장값 ] 이 존재할 경우 위의 두개를 불러옴
        if (PlayerPrefs.HasKey("Time"))
        {
            SurvivalTimeResultLongest.text = PlayerPrefs.GetString("Time");
            survivalTimeResultLongest = PlayerPrefs.GetInt("TimeR");
        }
    }

}
