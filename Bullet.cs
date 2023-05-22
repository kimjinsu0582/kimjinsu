using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    void Start()
    {
        
    }

    
    void Update()
    {
        //1.방향을 구한다
        Vector3 dir = Vector3.up;
        //2.이동하고 싶. 공식 P = p0 +vt
        transform.position += dir * speed * Time.deltaTime;

    }
}
