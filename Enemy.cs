using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    GameObject player;
    Vector3 dir;
    //1. 폭발공장 주소
    public GameObject explosionFactory;

    private void OnCollisionEnter(Collision other) //()->안에있는 변수는 Enemy와 부딪힌 상대방 게임 오브젝트의 충돌체
    {
        ScoreManager.Instance.Score++;
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if (other.gameObject.name.Contains("bullet")) //만약 부딪힌 물체가 불릿이라며
        {
            //2.부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);

            //PlayerFire 클래스 얻어오기
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            //리스트에 총알 삽입
            player.bulletObjectPool.Add(other.gameObject);

        }
        else
        {
            Destroy(other.gameObject);
        }
        //Destroy(gameObject);
        gameObject.SetActive(false);

        EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        //리스트에 총알 삽입
        manager.enemyObjectPool.Add(gameObject);

        //Destroy(collision.gameObject);
        //Destroy(gameObject);


        /* //<에너미를 잡을때마다 현재 점수를 표시하고 싶다.>
        ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);
        //2.폭발효과공장에서 폭발효과를 만들어야한다 .
        GameObject explosion = Instantiate(explosionFactory);
        //3.폭발효과를 발생시키고 싶다.
        explosion.transform.position = transform.position;
        Destroy(collision.gameObject);
        Destroy(gameObject); */




        /*GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        sm.SetScore(sm.GetScore() + 1);
        sm.currentScore++;
        sm.currentScoreUI.text = "현재점수 : " + sm.currentScore; */


        /*목표 : 최고점수를 표시하고 싶다.
        /if (sm.currentScore > sm.bestScore) //만약 현재점수가 최고점수를 초과했다면 
        {
            sm.bestScore = sm.currentScore; //최고 점수를 갱신시킨다.

            sm.bestScoreUI.text = "최고점수 : " + sm.bestScore; 
        }*/

        /*2.폭발 효과 공장에서 폭발 효과를 하나 만들어야한다.
        GameObject explosion = Instantiate(explosionFactory);
        //3. 폭발 효과를 발생시키고 싶다
        explosion.transform.position = transform.position;
        //충돌시작
        Destroy(collision.gameObject); //너 죽고 
        Destroy(gameObject); // 나 죽자 */

    }
    private void OnCollisionStay(Collision other)
    {
        //충돌 중

    }
    private void OnCollisionExit(Collision other)
    {
        // 충돌 끝
    }
    //방향을 start안에 있던 지역변수를 밖으로 꺼내 전역변수로 만들어준다. 이자리에 Vector3 dir; 있었다
    void Start()
    {
    }

    void OnEnable()
    {
        
    
    int randValue = UnityEngine.Random.Range(0, 10);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position; //방향을 구하고 싶다. target<-me
            dir.Normalize(); //방향의 크기를 1로 하고싶.

        }
        else
        {
            dir = Vector3.down;
        }
    }
    void Update()
    {
        // Vector3 dir = Vector3.down; 전역변수로 설정해줬으니 삭제한다.
        transform.position += dir * speed * Time.deltaTime;
    }
}
