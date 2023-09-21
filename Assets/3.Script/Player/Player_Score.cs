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
            ���̵��� �ϱ� ���ؼ�, 
            ������ Static���� �����ϴ� ���� �ƴ϶� 
            PlaterPrefs��� ���� ����Ͽ��� Ű-Value������ �����մϴ�. 
            ���� Ű�� �����Ѵٸ�, �ٽ� ����� ����Դϴ�.
         �ҷ��Ë�
        PlayerPrefs.GetInt("Score");
         */
        //������ �� 
        PlayerPrefs.SetInt("Score", player_Score);
    }
}
