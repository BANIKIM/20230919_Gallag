using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /*
     �Ѿ��� ���� �� �����̰� �־�ߵ�
     */
    [SerializeField] private GameObject Player_bullet;
    [SerializeField] private float Attack_Rate = 0.5f;

    public void TryAttack()
    {
        Instantiate(Player_bullet, transform.position, Quaternion.identity);
    }

    /*
     �ڷ�ƾ

    ������ ������Ʈ ������� Unity���� �ִ�. 
    ������ Start update Onenable ���� ����Ƽ �ݹ��Լ��� ���� ���ư���. 
    ������ �ڷ�ƾ�� ���� �Ǹ� ������� ������Ʈ���� �Ѿ�� �ȴ�.
    �� unity���� �� �� �ڷ�ƾ ���ž� ��� ���� �Ѵ���
    ������� ������ ���� �ȴ�. 
    ������ yield return �� ������ ��� �ϴµ�
    ������  yield return �� ������ �ð�,������,���� ��ŭ�� �ٽ� ������� unity����
    �ѱ�� �ȴ�. 
     
     
     */
    private IEnumerator TryAttack_co()
    {
        while(true)
        {
            Instantiate(Player_bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Attack_Rate);//������� Attack_Rate��ŭ unity���� ����.
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
