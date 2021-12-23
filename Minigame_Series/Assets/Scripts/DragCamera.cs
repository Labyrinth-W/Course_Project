using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    private Vector3 touchStart;
    public Camera cam;//카메라 넣기
    public float groundZ = 0;
    public float RX;//오른쪽 x축 범위
    public float UY;//위쪽 y축 범위
    public float LX;//왼쪽 x축 범위
    public float DY;//아래쪽 y축 범위
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(groundZ);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPosition(groundZ);
            Camera.main.transform.position += direction;//메인 카메라로 태그된 카메라
        }
        if(cam.transform.position.x>RX)cam.transform.position=new Vector3(RX,cam.transform.position.y,cam.transform.position.z);//오른쪽 범위
        if(cam.transform.position.x <LX)cam.transform.position = new Vector3(LX, cam.transform.position.y, cam.transform.position.z);//왼쪽 범위
        if (cam.transform.position.y >UY) cam.transform.position = new Vector3(cam.transform.position.x,UY, cam.transform.position.z);//위쪽 범위
        if (cam.transform.position.y <DY) cam.transform.position = new Vector3(cam.transform.position.x,DY, cam.transform.position.z);//아래쪽 범위
    }
    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
   
}