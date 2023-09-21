using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HpPostionSetter : MonoBehaviour
{
    [SerializeField] private Vector3 distance = Vector3.up * 35f;

    private GameObject Target;//달릴 에너미
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

        //에너미 오브젝트는 위치가 지속적으로 갱신이 되는데
        //이걸 어떻게 따라가지....?
        //UI -> Canvas 상속을 받고 있는데.. 상속을 에너미로 바꿔야되나...


        //카메라상의 오브젝트 포지션을 포인트로잡아서 vector3로 반환 해준다.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(Target.transform.position);

        UItransform.position = screenPosition + distance;


    }
}
