using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    public int numberlist = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void CardFlip()
    {
        RemeberGameManager rememberGameManager = GameObject.Find("RememberGameManager").GetComponent<RemeberGameManager>();

        this.gameObject.SetActive(true);

        if (numberlist - (numberlist - 1) == 1)
        {
            rememberGameManager.correcter.text = "훌륭합니다 !";
            rememberGameManager.nowcard++;
        }
        else
        {
            rememberGameManager.correcter.text = "안타깝습니다 . . .";
            rememberGameManager.hp--;
            rememberGameManager.counterTime = 5;
            rememberGameManager.remainTime = 5;
        }
        
        void CardResetAll()
        {

        }
    }
}
