using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_loop_background : MonoBehaviour
{

    [SerializeField]private float scrollRange = 9.9f;
    [SerializeField] private float scrollSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);


        if (transform.position.y <= -scrollRange)
        {
            Vector2 offset = new Vector2( 0, scrollRange * 2f);
            transform.position = (Vector2)transform.position + offset;//()는 형변환을 하기 위해 사용

        }
    }
}
