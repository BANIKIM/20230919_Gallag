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
    Object�� ���������� ����- �ı��� �Ǹ� �޸𸮿��� ���������� �Ҵ��ϰ� �Ҵ������ϴ�
    ���� �߻��� �ȴ�. 
    �̸� �����ϰ��� 
    Object�� �̸� ���� �� �ڷᱸ���� ����Ͽ� ��� �� �ݳ��ϴ� �������� 
    Ȱ��ȭ ��Ȱ��ȭ �� ����Ͽ� ������Ʈ�� ���� ������ ���� �� ����ϵ�,
    �ڷᱸ���� ����Ͽ�, �ְ� ���� ���������� �ݺ��ϸ�
    ������ �ı��� ���̻� �Ͼ�� �ʰ� 
    ������ ���⿡�� ���������� �����Ǵ� �� ó�� ���̰� �ȴ�.

     
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

            TakeOut_enemy(position);

            yield return wfs;

        }
    }

    private void SpawnEnemy_Hp(EnemyControll enemy)
    {
        GameObject SilderClone = Instantiate(Enemy_HpBar);

        //�θ� ������ ���� �޼ҵ�
        SilderClone.transform.SetParent(Canvas);
        SilderClone.transform.localScale = Vector3.one;//1 1 1


        SilderClone.GetComponent<Enemy_HpPostionSetter>().Setup(enemy.gameObject);
        SilderClone.GetComponent<Enemy_Hpviewer>().Setup(enemy);
    }

}
