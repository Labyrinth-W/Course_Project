using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject SpaceShip;

    GameObject m_button;
  
    RectTransform m_transform;

    void Start()
    {
        //m_button = GameObject.Find("MenuButton");

        //m_transform = m_button.GetComponent<RectTransform>();
    }

    public void ToCollectionSceneMove()
    {
        if (Time.timeScale == 1.0F)
        {
            Time.timeScale = 0.0F;
        }

        //m_transform.localPosition = new Vector3(-300.0f, 400.0f + 400.0f, 0.0f);
        SceneManager.LoadScene("Collection_Scene");
    }

    public void ToUniverseSceneMove()
    {
        //m_button.SetActive(true);

        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

        m_transform.localPosition = new Vector3(-750.0f, 400.0f, 0.0f);

        SceneManager.LoadScene("Universe_Scene");
    }
}
