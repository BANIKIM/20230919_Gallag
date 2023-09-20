using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{

    [SerializeField] private float ScroolRange = 9.9f;

  
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<=-ScroolRange)
        {
            BackGroundOffset();
        }
    }

    public void BackGroundOffset()
    {
        Vector2 offset = new Vector2(0, ScroolRange * 2f);
        transform.position = (Vector2)transform.position + offset;
    }
}
