using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Stage_Data stagedata;
    [SerializeField] private GameObject Enemy_Prefabs;
    [SerializeField] private float SpawnTime;


    private void Awake()
    {
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

            Instantiate(Enemy_Prefabs, position, Quaternion.identity);

            yield return wfs;

        }
    }

}
