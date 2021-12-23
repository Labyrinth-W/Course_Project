using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToUniverseScene : MonoBehaviour
{
     GameObject touch;
     Image touchScreen_Button;
    private bool is_buttonAlpha_zero;

    void Start()
    {
        touch = GameObject.Find("Touch_Button");
        touchScreen_Button = touch.GetComponent<Image>();
        is_buttonAlpha_zero = false;
    }

    void Update()
    {
        Color color = touchScreen_Button.color;

        if (touchScreen_Button.color.a <= 0)
        {
            is_buttonAlpha_zero = true;
        }
        else if (touchScreen_Button.color.a >= 1)
        {
            is_buttonAlpha_zero = false;
        }

        if (is_buttonAlpha_zero == false)
        {
            color.a -= 1.0f * Time.deltaTime;

            touchScreen_Button.color = color;
        }
        else if (is_buttonAlpha_zero == true)
        {
            color.a += 1.0f * Time.deltaTime;

            touchScreen_Button.color = color;
        }
    }

    public void ToUniverseSceneMove()
    {
        SceneManager.LoadScene("Universe_Scene");
    }
}
