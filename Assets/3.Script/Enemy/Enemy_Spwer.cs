using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spwer : MonoBehaviour
{
    
    [SerializeField] private Stage_Data stage_Data;
    [SerializeField] private GameObject Enemy_Prefabs;
    [SerializeField] private float SpawnTime;

    private void Awake()
    {
        StartCoroutine(SpawnEnemy_co());
    }

    private IEnumerator SpawnEnemy_co()
    {
        WaitForSeconds wfs = new WaitForSeconds(SpawnTime);
        // while 문은 지속적으로 반복이 됨.
        // 계속 new WaitForSeconds 다 가비지 컬렉터의 수집대상이 됩니다.
        // 그래서 WaitForSeconds 캐싱을 사용하여 가비지 컬렉터가 수집하지 않도록 합

        //캐싱이란?
        //컴퓨팅에서 오랜시간 걸리는 작업의 결과를 저장해서 시간과 비용이 절감 하는것
        while (true)
        {
            float positionX = Random.Range(stage_Data.LimitMin.x, stage_Data.LimitMax.x);

            Vector3 position = new Vector3(positionX, stage_Data.LimitMax.y + 1f,0);

            Instantiate(Enemy_Prefabs, position, Quaternion.identity);

            yield return wfs;

        }
    }



}
