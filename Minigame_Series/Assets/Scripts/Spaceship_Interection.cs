using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship_Interection : MonoBehaviour
{
    public GameObject pinecone;
    public GameObject scarlet;
    public GameObject froze;
    public GameObject mech;
    public GameObject plant;
    public GameObject ball;

    Rigidbody rigid;

    UI_Manager ui;

    void Start()
    {
        // UI 매니저의 불값 체크
        GameObject checkbool = GameObject.Find("UI_Manager");
        if (checkbool != null)
        {
            // UI 매니저의 불값을 ui에 적용 
            ui = checkbool.GetComponent<UI_Manager>();
        }

        // Interection의 rigidbody를 참조
        rigid = GetComponent<Rigidbody>();
    }

    public void Checkpoint_checker()
    {
        if (ui.checkpoint_pinecone)
        {
            ball.SetActive(true);
            rigid.velocity = Vector3.zero;
            ball.transform.position = new Vector3(-1.5f, -71, 100);
        }
        else
        {
            ball.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pinecone")
        {
            pinecone.SetActive(true);
            ball.SetActive(false);
        }

        if (collision.gameObject.tag == "Scarlet")
        {
            scarlet.SetActive(true);
            ball.SetActive(false);
        }

        if (collision.gameObject.tag == "Froze")
        {
            froze.SetActive(true);
            ball.SetActive(false);
        }

        if (collision.gameObject.tag == "Mechanic")
        {
            mech.SetActive(true);
            ball.SetActive(false);
        }

        if (collision.gameObject.tag == "Plant")
        {
            plant.SetActive(true);
            ball.SetActive(false);
        }
    }
}
