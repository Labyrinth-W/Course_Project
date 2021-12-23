using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    // ui - ui의 이미지
    // gameobject - 충돌 위치

    public GameObject ball;

    public GameObject pinecone_ui;
    public GameObject pinecone;

    public GameObject froze_ui;
    public GameObject froze;

    public GameObject mech_ui;
    public GameObject mech;

    public GameObject plant_ui;
    public GameObject plant;

    // checkpoint - 각 체크포인트가 됐는지를 확인
    public bool checkpoint_pinecone;
    public bool checkpoint_scarlet;
    public bool checkpoint_froze;
    public bool checkpoint_mech;
    public bool checkpoint_plant;

    // 닿았을 
    private GameObject cast_target;

    GameObject mouseParticleSpawner;
    public GameObject mouseParticle;

    void Start()
    {
        GameObject mouseParticleSpawner = GameObject.Find("MouseParticleSpawner");
        checkpoint_pinecone = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }
    void CastRay()
    {
        cast_target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        mouseParticleSpawner = Instantiate(mouseParticle, new Vector2(pos.x, pos.y), Quaternion.identity) as GameObject;

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            cast_target = hit.collider.gameObject;
        }
    }

    public void Pinecone_On()
    {
       checkpoint_pinecone = true;
       checkpoint_scarlet = false;
       checkpoint_froze = false;
       checkpoint_mech = false;
       checkpoint_plant = false;
     }

    public void Scarlet_On()
    {
        checkpoint_pinecone = false;
        checkpoint_scarlet = true;
        checkpoint_froze = false;
        checkpoint_mech = false;
        checkpoint_plant = false;
    }

    public void Froze_On()
    {
        checkpoint_pinecone = false;
        checkpoint_scarlet = false;
        checkpoint_froze = true;
        checkpoint_mech = false;
        checkpoint_plant = false;
    }

    public void Mech_On()
    {
        checkpoint_pinecone = false;
        checkpoint_scarlet = false;
        checkpoint_froze = false;
        checkpoint_mech = true;
        checkpoint_plant = false;
    }

    public void Plant_On()
    {
        checkpoint_pinecone = false;
        checkpoint_scarlet = false;
        checkpoint_froze = false;
        checkpoint_mech = false;
        checkpoint_plant = true;
    }
    public void Pinecone_Off()
    {
       checkpoint_pinecone = false;
    }

    public void Scarlet_Off()
    {
        checkpoint_scarlet = false;
    }

    public void Froze_Off()
    {
        checkpoint_froze = false;
    }

    public void Mech_Off()
    {
        checkpoint_mech = false;
    }

    public void Plant_Off()
    {
        checkpoint_plant = false;
    }
}
