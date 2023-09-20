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
        //근데 
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);//20배정도 빠르다.

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
            //죽음 메소드 넣어주세용...
            onDie();
            //동원아 여기에 나중에...데미지 메소드도 넣어줘...todo0920
            player.TakeDamage(1);
        }
    }
    public void onDie()
    {
        //Enemy 사망시 호출될 메소드
        Destroy(gameObject);
    }

}
