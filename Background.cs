using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material bgMaterial;
    public float scrollSpeed = 0.2f;
    void Update()
    {
        //2.움직이는 방향이 필요하다.
        Vector2 direction = Vector2.up;
        //3.스크롤하고 싶다. p = p0+vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
