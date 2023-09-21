using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    /*
     bullet 삭제 
       화면바깥으로 일정 거리를 나가게되면 Destory되도록 만들어 됨. 
        1.화면 사이즈
        2. 일정거리
    위로 나가는 경우
    좌로 나가는 경우
    아래로 나가는 경우 -> 적
    우로 나가는 경우


     */
    [SerializeField] private Stage_Data stage_Data;
    private float destoryWieght = 2.0f;
    [SerializeField] private Player_Score Playerscore;
    
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out Playerscore);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Enemy"))
        {
            Playerscore.set_Score(3);
            coll.GetComponent<EnemyControll>().TakeDamage(1);
            Destroy(gameObject);
        }
    }


    private void LateUpdate()
    {
        if(transform.position.y<stage_Data.LimitMin.y-destoryWieght||
            transform.position.y>stage_Data.LimitMax.y+destoryWieght||
            transform.position.x<stage_Data.LimitMin.x-destoryWieght||
            transform.position.x>stage_Data.LimitMax.x+destoryWieght)
        {
            Destroy(gameObject);
        }
    }

}
