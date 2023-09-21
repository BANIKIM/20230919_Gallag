using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Hpviewer : MonoBehaviour
{

    private EnemyControll enemy;
    private Slider slider;


    public void Setup(EnemyControll enemy)
    {
        this.enemy = enemy;
        TryGetComponent(out slider);
    }
    private void Update()
    {
        slider.value = enemy.CurrentHP / enemy.MAXHP;
    }

}
