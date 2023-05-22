using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //영역 안에 다른 물체가 감지될 경 
    {
        if (other.gameObject.name.Contains("Bullet") ||
            other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            //부딪힌 물체가 총알일 경우 총알 리스트에 삽입 
            if (other.gameObject.name.Contains("Bullet"))
            {

                //playerFire 클래스 얻어오기
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

                //리스트에 총알 삽입
                player.bulletObjectPool.Add(other.gameObject);
            }

            else if (other.gameObject.name.Contains("Enemy"))
            {
                //EnemyManager 클래스 얻어오기
                GameObject emObject = GameObject.Find("EnemyManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();
                //리스트에 총알 삽입
                manager.enemyObjectPool.Add(other.gameObject);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
