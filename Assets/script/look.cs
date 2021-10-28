using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{

    public float mouseSensitive = 100f;//마우스 감도

    public Transform Pbody;//플레이어 위치

    RaycastHit _rayhit;

    float xRotation = 0f;//회전각도
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//마우스 커서 비활성화
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")* mouseSensitive * Time.deltaTime;//마우스 입력
        float mouseY = Input.GetAxis("Mouse Y")* mouseSensitive * Time.deltaTime;//마우스 입력
        
        xRotation -= mouseY;//카메라를 y축으로 회전
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//최대 최소 설정

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//x축을 회전
        Pbody.Rotate(Vector3.up * mouseX);//오브젝트를 회전시킴
    }

}
