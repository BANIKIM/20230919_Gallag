using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    //player Hp 관련 변수들 
    private float MaxHP = 3f;
    private float currentHP;

    /*
     프로퍼티 중에 Get 함수를 구현하지 않고도 => 구현을 할수 있다.
     */
    public float MAXHP => MaxHP;
    public float CurrntHP => currentHP;

    private SpriteRenderer renderer;
    //------------------------------------


    private Movement2D movement2D;

    [SerializeField]private Stage_Data stagedata;
    [SerializeField] private Weapon weapon;

    private void Awake()
    {
        movement2D = transform.GetComponent<Movement2D>();
        weapon = transform.GetComponent<Weapon>();

        currentHP = MaxHP;
        TryGetComponent(out renderer);


    }
    private void Start()
    {
        if(movement2D.Move_Speed<=0f)
        {
            movement2D.Move_Speed = 5f;
        }
    }
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            weapon.StartFire();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            weapon.StopFire();
        }

    }
    private void LateUpdate()
    {
        //플레이어가 화면 범위 바깥으로 나가지 못하도록 설정
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x,stagedata.LimitMin.x,stagedata.LimitMax.x),
            Mathf.Clamp(transform.position.y,stagedata.LimitMin.y,stagedata.LimitMax.y),
            0
            );
    }
    //데미지 and  Hit Action and 죽는 메소드 만들어 주세용
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        Debug.Log("Player Hp : " + currentHP);
        //HitColor_Action_co
        StopCoroutine("HitColor_Action_co");
        StartCoroutine("HitColor_Action_co");


        if (currentHP<=0)
        {
            //디져~
            onDie();
            SceneManager.LoadScene("Gameover");

        }

    }
    private void onDie()
    {
        Destroy(gameObject);

    }

    private IEnumerator HitColor_Action_co()
    {
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        renderer.color = Color.white;

    }








}
