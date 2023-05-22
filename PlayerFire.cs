using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알을 생산할 공장
    public GameObject bulletFactory;
    public int poolSize = 30; // 탄창에 넣을 수 있는 총알의 개수

    public List<GameObject> bulletObjectPool; //오브젝트 풀 배열(=같은 종류의 데이터를 그룹으로 관리)
    void Start()
    {
        //2.탄창을 총알 담을 수 있는 크기로 만들어준다
        bulletObjectPool = new List<GameObject>();
        //3.탄창에 넣을 총알 개수만큼 반복해
        for (int i = 0; i < poolSize; i++)
        {

            //4.총알공장에서 총알을 생성한다
            GameObject bullet = Instantiate(bulletFactory);
            //5.총알을 오브젝트 풀에 넣고 싶다
            bulletObjectPool.Add(bullet);
            //비활성화 시키자
            bullet.SetActive(false);
        }
    }

    // 총구
    //public GameObject firePosition;

    // Update is called once per frame
    void Update()
    {
        //1.만약 사용자가 발사 버튼을 누른다면
        if (Input.GetButtonDown("Fire1"))
        {
            //2.탄창안에 있는 총알들 중에서
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);
                bullet.transform.position = transform.position;
            }






            /* for (int i = 0; i < poolSize; i++)
                {
            //3.비활성화된 총알을
            //만약 총알이 비활성화됐다면
            GameObject bullet = bulletObjectPool[i];
                if (bullet.activeSelf == false)
                 {
                //총알을 발사하고 싶다
                bullet.SetActive(true);
                //총알 위치시키기
                bullet.transform.position = transform.position;
                //총알을 발사했기 때문에 비활성화 총알 검색 중단
                break;
            

                 }
                }*/
        }
    }
}
