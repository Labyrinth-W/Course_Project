using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Create : MonoBehaviour
{
    public Transform towerPrefeb;
    public float towerTransformY;

    private void Start()
    {
        towerTransformY = 0;
    }
    public void TowerCreate()
    {
        Instantiate(towerPrefeb, new Vector3(-2, towerTransformY, 108), Quaternion.identity);

        towerTransformY += 1.5f;
    }
}
