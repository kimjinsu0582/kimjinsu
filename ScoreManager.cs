using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text currentScoreUI;
    private int currentScore;
    public Text bestScoreUI;
    private int bestScore;

    /*public void SetScore(int value)
    {
        currentScore = value; //ScoreManaget 클래스의 속성에 값을 할당한다.
        currentScoreUI.text = "현재점수 : " + currentScore;
        //목표 : 최고 점수를 표시하고 싶다.
        //1. 현재 점수가 최고 점수보다 크니까
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "최고점수 : " + bestScore;
            //목표 : 최고점수를 저장하고 싶다
            PlayerPrefs.SetInt("Best Score", bestScore);

        }

    }*/

    //싱글턴 객체
    public static ScoreManager Instance = null;

    //싱글턴 객체에 값이 없으면 생성된 자기 자신을 할당
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value; // 클래스의 속성에 값을 할당
            currentScoreUI.text = "현재 점수 : " + currentScore;
            //목표 : 최고점수를 표시하고 싶다.
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고 점수 : " + bestScore;
                //목표 : 최고점수를 저장하고 싶다
                PlayerPrefs.SetInt("Best Score", bestScore);

            }
        }
    }
    void Start()
    {
        //목표 : 최고 점수를 불러와 bestScore 변수에 할당하고 화면에 표시한.
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고점수 : " + bestScore;

    }

    
    /*public int GetScore()
    {
        return currentScore;
    }*/

    
    void Update()
    {
        
    }
}
