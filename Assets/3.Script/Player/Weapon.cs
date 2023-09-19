using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /*
     총알은 나갈 때 딜레이가 있어야되
     */
    [SerializeField] private GameObject Player_bullet;
    [SerializeField] private float Attack_Rate = 0.5f;

    public void TryAttack()
    {
        Instantiate(Player_bullet, transform.position, Quaternion.identity);
    }

    /*
     코루틴

    원래의 오브젝트 제어권이 Unity한테 있다. 
    이유는 Start update Onenable 같이 유니티 콜백함수의 의해 돌아간다. 
    하지만 코루틴을 쓰게 되면 제어권이 오브젝트한테 넘어가게 된다.
    즉 unity한테 나 이 코루틴 쓸거야 라고 말을 한다음
    제어권을 가지고 오게 된다. 
    하지만 yield return 을 무조건 써야 하는데
    이유는  yield return 의 지정한 시간,프레임,단위 만큼은 다시 제어권을 unity한테
    넘기게 된다. 
     
     
     */
    private IEnumerator TryAttack_co()
    {
        while(true)
        {
            Instantiate(Player_bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Attack_Rate);//제어권이 Attack_Rate만큼 unity한테 간다.
        }
    }
    public void StartFire()
    {
        StartCoroutine("TryAttack_co");
    }
    public void StopFire()
    {
        StopCoroutine("TryAttack_co");
    }
}
