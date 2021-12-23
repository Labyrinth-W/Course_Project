using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_Manager_S : MonoBehaviour
{
    public Transform resource_Image;
    public Transform collection_Image;

    // Resource_Screen - 자원창
    // Collection_Screen - 도감창
    // Call은 창을 보이게, Rollback은 창을 숨기게 함
    public void Resource_Screen_Call()
    {
        resource_Image = GameObject.Find("Resource_Screen").GetComponent<Transform>();
     
            Vector3 pos = resource_Image.transform.localPosition;

            if (pos.x >= -1300 && pos.x <= -660)
            {
                pos.x = -660;
            }
            resource_Image.transform.localPosition = pos;        
    }

    public void Resource_Screen_Rollback()
    {
        resource_Image = GameObject.Find("Resource_Screen").GetComponent<Transform>();

        Vector3 pos = resource_Image.transform.localPosition;

        if (pos.x >= -1300 && pos.x <= -660)
        {
            pos.x = -1300;
        }
        resource_Image.transform.localPosition = pos;
    }

    public void Collection_Screen_Call()
    {
        collection_Image = GameObject.Find("Collection_Screen").GetComponent<Transform>();

        Vector3 colpos = collection_Image.transform.localPosition;

        colpos.x = 560;

        collection_Image.transform.localPosition = colpos;
    }

    public void Collection_Screen_Rollback()
    {
        collection_Image = GameObject.Find("Collection_Screen").GetComponent<Transform>();

        Vector3 colpos = collection_Image.transform.localPosition;

        colpos.x = 1400;

        collection_Image.transform.localPosition = colpos;
    }
}
