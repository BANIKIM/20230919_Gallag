using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    [SerializeField] private Stage_Data stageData;
    [SerializeField] private Player_Controller player;
    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        //�ٵ� 
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);//20������ ������.

        //if (!GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player))
        //{
        //    GameObject.FindGameObjectWithTag("Player").AddComponent<Player_Controller>();
        //    GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);
        //}
    }
    private void Update()
    {
        if(transform.position.y<stageData.LimitMin.y-2f)
        {
            onDie();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            //���� �޼ҵ� �־��ּ���...
            onDie();
            //������ ���⿡ ���߿�...������ �޼ҵ嵵 �־���...todo0920
            player.TakeDamage(1);
        }
    }
    public void onDie()
    {
        //Enemy ����� ȣ��� �޼ҵ�
        Destroy(gameObject);
    }

}
