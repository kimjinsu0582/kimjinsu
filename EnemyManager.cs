using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public float minTime = 0.5f;
    public float maxTime = 1.5f;


   
    float currentTime;
    public float creatTime = 1; // 일정시쳐
    public GameObject enemyFactory; //적 공장 

    public int poolSize = 30;
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints; //SpawnPoint들
                                    
    void Start()
    {
        // 태어날때 적의 생성시간을 설정하고
        creatTime = Random.Range(minTime, maxTime);

        //2. 오브젝트 풀을 에너미들을 담을 수 있는 크기로 만들어준다
        enemyObjectPool = new List<GameObject>();

        //3. 오브젝트 풀에 넣을 에너미 개수만큼 반복해
        for (int i = 0; i < poolSize; i++)
        {
            //4. 에너미 공장에서 에너미를 생산한다
            GameObject enemy = Instantiate(enemyFactory);
            //5. 에너미를 오브젝트 풀에 넣고 싶다
            enemyObjectPool.Add(enemy);
            //비활성화 시키자
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; //1.시간이 흐르다가
        if (currentTime > creatTime) // 2. 만약 현재시간이 일정 시간이 되면
        {
            //2. 오브젝트풀에 에너미가 있다면
            if (enemyObjectPool.Count > 0)
            {
                //오브젝트풀에서 enemy를 가져다 사용하도록 한다
                GameObject enemy = enemyObjectPool[0];
                //오브젝트풀에서 에너미 제거
                enemyObjectPool.Remove(enemy);
                //랜덤으로 인덱스 선택
                int index = Random.Range(0, spawnPoints.Length);
                //에너미 위치시키기
                enemy.transform.position = spawnPoints[index].position;
                //에너미를 활성화하고 싶.
                enemy.SetActive(true);

            }    
            
            creatTime = Random.Range(minTime, maxTime);
            currentTime = 0; //현재시간을 0으로 초기화

        }
    }
}
