using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;

    public int bestScore;

    public int level;

    public void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
            

        }
        

    }


    void Start()
    {
        

        score = 0;

        level = 1;

        GameManager.Instance.LevelText.text = level.ToString();

        GameManager.Instance.scoreNumberText.text = score.ToString();

        GameManager.Instance.BestScoreNumber.text = bestScore.ToString();

    }

 

    public void LevelUpdate()
    {
        if (score % 100 == 0)
        {
            level++;
            GameManager.Instance.LevelText.text = level.ToString();
            
        }
    }

    public void UpdateScore()
    {
        BestScore();
        GameManager.Instance.scoreNumberText.text = score.ToString();
    }

    public void BestScore()
    {
        if(score > bestScore)
        {
            bestScore = score;

            GameManager.Instance.BestScoreNumber.text = bestScore.ToString();

            PlayerPrefs.SetInt("BestScore", bestScore);

            
            
        }
    }
}
