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
        // while ���� ���������� �ݺ��� ��.
        // ��� new WaitForSeconds �� ������ �÷����� ��������� �˴ϴ�.
        // �׷��� WaitForSeconds ĳ���� ����Ͽ� ������ �÷��Ͱ� �������� �ʵ��� ��

        //ĳ���̶�?
        //��ǻ�ÿ��� �����ð� �ɸ��� �۾��� ����� �����ؼ� �ð��� ����� ���� �ϴ°�
        while (true)
        {
            float positionX = Random.Range(stage_Data.LimitMin.x, stage_Data.LimitMax.x);

            Vector3 position = new Vector3(positionX, stage_Data.LimitMax.y + 1f,0);

            Instantiate(Enemy_Prefabs, position, Quaternion.identity);

            yield return wfs;

        }
    }



}
