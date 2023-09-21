using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HpPostionSetter : MonoBehaviour
{
    [SerializeField] private Vector3 distance = Vector3.up * 35f;

    private GameObject Target;//�޸� ���ʹ�
    private RectTransform UItransform;

    public void Setup(GameObject target)
    {
        Target = target;
        UItransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if(!Target.activeSelf)
        {
            Destroy(gameObject);
            return;
        }

        //���ʹ� ������Ʈ�� ��ġ�� ���������� ������ �Ǵµ�
        //�̰� ��� ������....?
        //UI -> Canvas ����� �ް� �ִµ�.. ����� ���ʹ̷� �ٲ�ߵǳ�...


        //ī�޶���� ������Ʈ �������� ����Ʈ����Ƽ� vector3�� ��ȯ ���ش�.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(Target.transform.position);

        UItransform.position = screenPosition + distance;


    }
}
