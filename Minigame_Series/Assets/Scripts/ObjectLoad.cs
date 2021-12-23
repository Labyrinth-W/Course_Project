using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoad : MonoBehaviour
{
    private void Awake()
    {
        var objec = FindObjectsOfType<ObjectLoad>();

        if (objec.Length == 10)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
