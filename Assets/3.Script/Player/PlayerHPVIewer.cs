using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPVIewer : MonoBehaviour
{
    [SerializeField] private Slider sliderHP;
    [SerializeField] private Player_Controller player;

    private void Start()
    {
        TryGetComponent(out sliderHP);
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);
    }
    private void Update()
    {
        sliderHP.value = player.CurrntHP / player.MAXHP;

    }
}
