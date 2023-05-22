using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5; //float는 유리수, int는 정수

    void Start()
    {
        
    }

    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // print("h : " + h + ",v : " + v);

        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        //transform.Translate(Vector3.right * speed * Time.deltaTime); -> 이거 두줄을 간략하게하기
        
        Vector3 dir = new Vector3(h, v, 0);

        //Time.deltaTime = 이전 프레의 발생시각과 현재프레임 발생시각 사이의 시간간격
        // 즉, 이전 프레임의 수행에 걸린 시간
        // transform.Translate = 일정속도를 가지고 일정거리만큼씩 연속으로 이동하는 모습이 보인다.
        // 위에 내용은 p = p0+ vt 공식으로 변형
        transform.position += dir * speed * Time.deltaTime;
    }
}
