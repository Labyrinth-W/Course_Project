using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipChanger : MonoBehaviour
{
    GameObject spaceShip;
    SpriteRenderer ss_Image;

    public Sprite classicShip;
    public Sprite yellowShip;
    public Sprite purpleShip;
    public Sprite pinkShip;
    public Sprite watermelonShip;
    public Sprite meowShip;
    public Sprite mirrorballShip;
    public Sprite beeShip;

    void Start()
    {
        spaceShip = GameObject.Find("Ball");
        ss_Image = spaceShip.GetComponent<SpriteRenderer>();
    }

    public void ChangeClassicShip()
    {
        ss_Image.sprite = classicShip;
    }

    public void ChangeYellowShip()
    {
        ss_Image.sprite = yellowShip;
    }

    public void ChangePurpleShip()
    {
        ss_Image.sprite = purpleShip;
    }

    public void ChangePinkShip()
    {
        ss_Image.sprite = pinkShip;
    }

    public void ChangeWatermelonShip()
    {
        ss_Image.sprite = watermelonShip;
    }

    public void ChangeMeowShip()
    {
        ss_Image.sprite = meowShip;
    }
    public void ChangeMirrorballShip()
    {
        ss_Image.sprite = mirrorballShip;
    }

    public void ChangeBeeShip()
    {
        ss_Image.sprite = beeShip;
    }
}
