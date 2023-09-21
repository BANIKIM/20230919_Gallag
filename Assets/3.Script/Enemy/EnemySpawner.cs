using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int Enemy_count = 10;


    private Queue<GameObject> Enemy_queue;
    private Vector3 poolposition = new Vector3(0, -25f, 0);

    [SerializeField] private Stage_Data stagedata;
    [SerializeField] private GameObject Enemy_Prefabs;
    [SerializeField] private float SpawnTime;

    [SerializeField] private GameObject Enemy_HpBar;
    [SerializeField] private Transform Canvas;


    private void Awake()
    {
     

        Enemy_queue = new Queue<GameObject>();
        for(int i=0;i<Enemy_count;i++)
        {
            GameObject enemy = Instantiate(Enemy_Prefabs, poolposition, Quaternion.identity);
            enemy.SetActive(false);
            Enemy_queue.Enqueue(enemy);
        }


        StartCoroutine(SpawnEnemy_co());
    }
    /*
     Object Pooling
    Object가 지속적으로 생성- 파괴가 되면 메모리에서 지속적으로 할당하고 할당해제하는
    일이 발생이 된다. 
    이를 방지하고자 
    Object를 미리 생성 후 자료구조를 사용하여 사용 후 반납하는 개념으로 
    활성화 비활성화 를 사용하여 오브젝트를 일정 개수만 생성 후 사용하든,
    자료구조를 사용하여, 넣고 뺴고를 지속적으로 반복하면
    생성과 파괴가 더이상 일어나지 않고도 
    유저가 보기에는 지속적으로 생성되는 것 처럼 보이게 된다.

     
     */
    public void TakeOut_enemy(Vector3 position)
    {
        if (Enemy_queue.Count <= 0) return;
        GameObject Enemy = Enemy_queue.Dequeue();
        if(!Enemy.activeSelf)
        {
            Enemy.SetActive(true);
        }
        Enemy.transform.position = position;
        SpawnEnemy_Hp(Enemy.GetComponent<EnemyControll>());
    }
    public void Takein_enemy(GameObject Enemy)
    {
        Enemy.transform.position = poolposition;
        if(Enemy.activeSelf)
        {
            Enemy.SetActive(false);
        }
        Enemy_queue.Enqueue(Enemy);
    }

    private IEnumerator SpawnEnemy_co()
    {
        WaitForSeconds wfs = new WaitForSeconds(SpawnTime);
        //while문은 지속적으로 반복이 됨. 
        /*
         근데....계속 new WaitForSeconds 모조리다 가비지컬렉터의
        수집 대상됩니다. 
        그래서~ 나는 WaitForSeconds 캐싱이라는것 사용하여서
        가비지컬렉터가 수집하지 않도록 만들겁니다. 

        여기서 캐싱이란?
            캐싱이란 컴퓨팅에서 오랜시간 걸리는 작업의 결과를 저장해서
        시간과 비용을 절감하는 기법
         
         */
        while (true)
        {
            float positionX = Random.Range(stagedata.LimitMin.x,
                stagedata.LimitMax.x);
            Vector3 position = new Vector3(positionX,
                stagedata.LimitMax.y + 1f, 0);

            TakeOut_enemy(position);

            yield return wfs;

        }
    }

    private void SpawnEnemy_Hp(EnemyControll enemy)
    {
        GameObject SilderClone = Instantiate(Enemy_HpBar);

        //부모 설정을 위한 메소드
        SilderClone.transform.SetParent(Canvas);
        SilderClone.transform.localScale = Vector3.one;//1 1 1


        SilderClone.GetComponent<Enemy_HpPostionSetter>().Setup(enemy.gameObject);
        SilderClone.GetComponent<Enemy_Hpviewer>().Setup(enemy);
    }

}
