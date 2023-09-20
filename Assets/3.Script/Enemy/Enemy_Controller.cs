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

        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);//GetComponent 보다 20배정도 빠르다.


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //죽음 메서드
            OnDie();
            //나중에 데미지 메소드도 넣어주 todo0920
            player.TakeDamage(1);


        }
    }

    public void OnDie()
    {
        //Enemy가 사망시 호출될 메소드
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
