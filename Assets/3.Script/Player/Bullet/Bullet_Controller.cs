using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    /*
     bullet ���� 
       ȭ��ٱ����� ���� �Ÿ��� �����ԵǸ� Destory�ǵ��� ����� ��. 
        1.ȭ�� ������
        2. �����Ÿ�
    ���� ������ ���
    �·� ������ ���
    �Ʒ��� ������ ��� -> ��
    ��� ������ ���


     */
    [SerializeField] private Stage_Data stage_Data;
    private float destoryWieght = 2.0f;

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
