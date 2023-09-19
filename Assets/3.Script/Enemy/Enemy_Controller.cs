using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    // Start is called before the first frame update
    private void Awake()
    {
        weapon = transform.GetComponent<Weapon>();
        weapon.StartFire();
    }
}
