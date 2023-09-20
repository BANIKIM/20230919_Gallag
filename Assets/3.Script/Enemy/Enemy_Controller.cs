using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private Player_Controller player;
    [SerializeField] private Stage_Data stage_Data;
    private float destoryWieght = 2.0f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        //

        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);//GetComponent ���� 20������ ������.


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //���� �޼���
            OnDie();
            //���߿� ������ �޼ҵ嵵 �־��� todo0920
            player.TakeDamage(1);


        }
    }

    public void OnDie()
    {
        //Enemy�� ����� ȣ��� �޼ҵ�
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        if (transform.position.y < stage_Data.LimitMin.y - destoryWieght ||
           transform.position.y > stage_Data.LimitMax.y + destoryWieght ||
           transform.position.x < stage_Data.LimitMin.x - destoryWieght ||
           transform.position.x > stage_Data.LimitMax.x + destoryWieght)
        {
            Destroy(gameObject);
        }
    }

}
