﻿using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }
    private void IncrementScore()
    {
        score += 1;
    }
    public void StartScore()
    {
        InvokeRepeating(nameof(IncrementScore), 0.1f, 0.5f);
    }
    public void StopScore()
    {
        CancelInvoke(nameof(IncrementScore));
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        } 
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
