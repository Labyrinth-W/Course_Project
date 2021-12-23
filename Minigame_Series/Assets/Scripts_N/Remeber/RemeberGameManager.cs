using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RemeberGameManager : MonoBehaviour
{

    public GameObject Clocking;

    // 맨 위부터 체력, 생존 회수, 추가 카드 횟수
    public Text HpText;
    public float hp = 2;

    public Text SurvivatlCountText;
    public Text PlusCardText;

    // 제한 시간

    public Text RemainTime;
    public float remainTime = 5;

    // 게임오버 시 최종 생존 횟수
    public Text sCountResult;
    int survivalCountResult;

    // 생존 시간 중에서 최고 생존 횟수
    public Text SurvivalCountResultLongest;
    int survivalCountResultLongest = 0;

    // 텍스트
    public Text correcter;

    // 게임 오버 창
    public GameObject GameOver;

    // 시작 버튼 창
    public GameObject StartButton;

    // 카운트다운 오브젝트
    public Text Counter;
    public float counterTime = 4;

    // 게임 시작 확인
    bool start;

    // 카운트다운 시작 확인
    bool startcounter = false;

    // 올려야하는 총 카운트
    public int totalcardneed = 4;

    // 올라간 카운트
    public int nowcard = 0;

    // 카드와 좌표지점 위치

    GameObject cardA, cardB, cardC, cardD, cardE, cardF, cardG, cardH, cardI, cardJ;
    GameObject cooA, cooB, cooC, cooD, cooE, cooF, cooG, cooH, cooI, cooJ;
    Vector3 posA, posB, posC, posD, posE, posF, posG, posH, posI, posJ;
    Vector3 posCA, posCB, posCC, posCD, posCE, posCF, posCG, posCH, posCI, posCJ;

    void Start()
    {
        getCard();
        getCoord();
        getPos();

        Time.timeScale = 0;
        start = false;

        StartButton.SetActive(true);
    }

   
    void Update()
    {

        if (startcounter)
        {
            counterTime -= Time.deltaTime;
            Counter.text = "" + (int)counterTime;

            if (counterTime <= 0)
            {
                remainTime -= Time.deltaTime;

                if (remainTime <= 0)
                {
                    hp--;
                    counterTime = 5;
                }
            }
        }

        if (start)
        {
            HpText.text = "남은 체력 : " + (int)hp + " HP";
            SurvivatlCountText.text = "성공 횟수 : ";
            PlusCardText.text = "카드 추가 : ";

            // 체력이 0이 되면 게임오버 함수 호출
            if (hp <= 0)
            {
                GameOverScreen();
            }
        }

    }

    public void getCard()
    {
        cardA = GameObject.Find("Card A");
        cardB = GameObject.Find("Card B");
        cardC = GameObject.Find("Card C");
        cardD = GameObject.Find("Card D");
        cardE = GameObject.Find("Card E");
        cardF = GameObject.Find("Card F");
        cardG = GameObject.Find("Card G");
        cardH = GameObject.Find("Card H");
        cardI = GameObject.Find("Card I");
        cardJ = GameObject.Find("Card J");
    }

    public void getCoord()
    {
        cooA = GameObject.Find("Coordinate1");
        cooB = GameObject.Find("Coordinate2");
        cooC = GameObject.Find("Coordinate3");
        cooD = GameObject.Find("Coordinate4");
        cooE = GameObject.Find("Coordinate5");
        cooF = GameObject.Find("Coordinate6");
        cooG = GameObject.Find("Coordinate7");
        cooH = GameObject.Find("Coordinate8");
        cooI = GameObject.Find("Coordinate9");
        cooJ = GameObject.Find("Coordinate10");
    }

    public void getPos()
    {
        posA = cardA.gameObject.transform.position;
        posB = cardB.gameObject.transform.position;
        posC = cardC.gameObject.transform.position;
        posD = cardD.gameObject.transform.position;
        posE = cardE.gameObject.transform.position;
        posF = cardF.gameObject.transform.position;
        posG = cardG.gameObject.transform.position;
        posH = cardH.gameObject.transform.position;
        posI = cardI.gameObject.transform.position;
        posJ = cardJ.gameObject.transform.position;

        posCA = cooA.gameObject.transform.position;
        posCB = cooB.gameObject.transform.position;
        posCC = cooC.gameObject.transform.position;
        posCD = cooD.gameObject.transform.position;
        posCE = cooE.gameObject.transform.position;
        posCF = cooF.gameObject.transform.position;
        posCG = cooG.gameObject.transform.position;
        posCH = cooH.gameObject.transform.position;
        posCI = cooI.gameObject.transform.position;
        posCJ = cooJ.gameObject.transform.position;
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
 
        start = true;
        startcounter = false;
        Counter.gameObject.SetActive(false);
        Clocking.SetActive(false);

    }

    public void GameOverScreen()
    {
        // 게임을 정지시키고 최종 생존 시간 계산
        Time.timeScale = 0;
        GameOver.SetActive(true);

        // 제일 최근의 최고 생존 시간 로드
        Load();

        // 최종 생존 시간이 최고 생존 시간보다 높을 경우 갱신, 후 저장
        if (survivalCountResult > survivalCountResultLongest)
        {
            survivalCountResultLongest = survivalCountResult;
        }

        Save();

        sCountResult.text = "최종 생존 시간 : " + survivalCountResult + " 초";
        SurvivalCountResultLongest.text = "최고 생존 시간 : " + survivalCountResultLongest + " 초";
    }

    public void Save()
    {
        // 최종 생존 시간 값과 텍스트를 PlayerPrefs에 저장
        PlayerPrefs.SetString("Time", SurvivalCountResultLongest.text);
        PlayerPrefs.SetInt("TimeR", survivalCountResultLongest);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        // Time이라는 Key [ 저장값 ] 이 존재할 경우 위의 두개를 불러옴
        if (PlayerPrefs.HasKey("Time"))
        {
            SurvivalCountResultLongest.text = PlayerPrefs.GetString("Time");
            survivalCountResultLongest = PlayerPrefs.GetInt("TimeR");
        }
    }

}
