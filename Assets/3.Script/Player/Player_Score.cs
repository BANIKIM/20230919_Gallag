using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    private int player_Score = 0;
    //public int Player_Socre { get; set; }
    public int Player_Socre => player_Score;

    [SerializeField] private Text Score;

    private void Awake()
    {
        player_Score = 0;
    }
    public void set_Score(int score)
    {
        player_Score += score;
        Score.text = $"Score : {player_Score}";
    }

    public void SaveScore()
    {
        /*
         PlayerPrefs?
            씬이동을 하기 위해서, 
            변수를 Static으로 선언하는 것이 아니라 
            PlaterPrefs라는 것을 사용하여서 키-Value값으로 저장합니다. 
            만약 키가 존재한다면, 다시 덮어쓰는 방식입니다.
         불러올떄
        PlayerPrefs.GetInt("Score");
         */
        //저장할 떄 
        PlayerPrefs.SetInt("Score", player_Score);
    }
}
