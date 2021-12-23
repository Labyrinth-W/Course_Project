using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Manager : MonoBehaviour
{
    public Text gold_text;
    public int gold_left;


    void Update()
    {
          
    }

    public void PlusGoldUp()
    {
        gold_left += 20;
    }
}
