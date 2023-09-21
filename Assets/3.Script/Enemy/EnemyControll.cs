using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;

    [SerializeField] private Stage_Data stageData;
    [SerializeField] private Player_Controller player;

    //HP관련 변수들
    private float MaxHP = 2f;
    private float currentHP;

    public float MAXHP => MaxHP;
    public float CurrentHP => currentHP;

    [SerializeField] private SpriteRenderer renderer;

    private bool isDie;

    //private void Awake()
    //{
    //    //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
    //    //근데 
    //    //GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);//20배정도 빠르다.
    //    //GameObject.FindGameObjectWithTag("Enemy_Spawner").TryGetComponent(out spawner);
    //    //if (!GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player))
    //    //{
    //    //    GameObject.FindGameObjectWithTag("Player").AddComponent<Player_Controller>();
    //    //    GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);
    //    //}
    //}

    private void OnEnable()
    {
        currentHP = MaxHP;//hp초기화
        renderer = GetComponent<SpriteRenderer>();
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);//20배정도 빠르다.
        GameObject.FindGameObjectWithTag("Enemy_Spawner").TryGetComponent(out spawner);
        renderer.color = Color.white;
        isDie = false;
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
            //넣었어 임마...
            player.TakeDamage(1);
        }
    }
    public void onDie()
    {
        //Enemy 사망시 호출될 메소드
        //Destroy(gameObject);
        spawner.Takein_enemy(gameObject);
        isDie = true;
    }
    
    public void TakeDamage(float Damage)
    {
        currentHP -= Damage;
        if(!isDie)
        {
            //효과를 넣어주세용
            StopCoroutine("Hitanimation_co");
            StartCoroutine("Hitanimation_co");
        }

        if(currentHP<=0)
        {
            onDie();
        }
    }

    private IEnumerator Hitanimation_co()
    {
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        renderer.color = Color.white;
    }

}
