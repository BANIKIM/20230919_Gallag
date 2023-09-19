using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    private int HitCount = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        weapon = transform.GetComponent<Weapon>();


        weapon.StartFire();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player_Bullet"))
        {
            HitCount++;
        }

        if(HitCount==3)
        {
            Destroy(gameObject);
        }
    }
}
