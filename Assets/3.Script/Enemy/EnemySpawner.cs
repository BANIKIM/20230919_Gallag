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
    Object�� ���������� ����- �ı��� �Ǹ� �޸𸮿��� ���������� �Ҵ��ϰ� �Ҵ������ϴ�
    ���� �߻��� �ȴ�. 
    �̸� �����ϰ��� 
    Object�� �̸� ���� �� �ڷᱸ���� ����Ͽ� ��� �� �ݳ��ϴ� �������� 
    Ȱ��ȭ ��Ȱ��ȭ �� ����Ͽ� ������Ʈ�� ���� ������ ���� �� ����ϵ�,
    �ڷᱸ���� ����Ͽ�, �ְ� ���� ���������� �ݺ��ϸ�
    ������ �ı��� ���̻� �Ͼ�� �ʰ� 
    ������ ���⿡�� ���������� �����Ǵ� �� ó�� ���̰� �ȴ�.

     
     */

    private IEnumerator SpawnEnemy_co()
    {
        WaitForSeconds wfs = new WaitForSeconds(SpawnTime);
        //while���� ���������� �ݺ��� ��. 
        /*
         �ٵ�....��� new WaitForSeconds �������� �������÷�����
        ���� ���˴ϴ�. 
        �׷���~ ���� WaitForSeconds ĳ���̶�°� ����Ͽ���
        �������÷��Ͱ� �������� �ʵ��� ����̴ϴ�. 

        ���⼭ ĳ���̶�?
            ĳ���̶� ��ǻ�ÿ��� �����ð� �ɸ��� �۾��� ����� �����ؼ�
        �ð��� ����� �����ϴ� ���
         
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
